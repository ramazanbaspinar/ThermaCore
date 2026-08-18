using System.Security.Cryptography;
using System.Text.Json;
using WinBeyazEsya.Application.DTOs.Updater;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Application.Interfaces.Updater;

namespace WinBeyazEsya.Application.Services.Updater
{
    public class AutoUpdateManager : IAutoUpdateService
    {
        private readonly ISystemParameterService _systemParameterService;

        public AutoUpdateManager(ISystemParameterService systemParameterService)
        {
            _systemParameterService = systemParameterService;
        }

        public async Task<UpdateManifestDto> CheckForUpdatesAsync()
        {
            try
            {
                var systemParam = await _systemParameterService.GetSystemParameterAsync();
                string serverUrl = systemParam?.UpdatePath;

                if (string.IsNullOrWhiteSpace(serverUrl))
                    return null; // Update yolu ayarlanmamışsa sessizce geç

                bool isHttp = serverUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                              serverUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
                string manifestJson = "";

                if (isHttp)
                {
                    using (var http = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                    {
                        string url = serverUrl.EndsWith("/") ? serverUrl : serverUrl + "/";
                        url += "update_manifest.json";
                        manifestJson = await http.GetStringAsync(url);
                    }
                }
                else
                {
                    string path = Path.Combine(serverUrl, "update_manifest.json");
                    if (File.Exists(path))
                        manifestJson = File.ReadAllText(path);
                }

                if (string.IsNullOrWhiteSpace(manifestJson)) return null;

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                };

                var manifest = JsonSerializer.Deserialize<UpdateManifestDto>(manifestJson, options);

                if (manifest == null)
                {
                    Serilog.Log.Warning("Güncelleme kontrolü: Manifest deserialization sonucu null döndü.");
                    return null;
                }

                Serilog.Log.Information("Güncelleme kontrolü başarılı. Sunucudaki versiyon: {Version}", manifest.Version);
                return manifest;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "CheckForUpdatesAsync işleminde hata oluştu.");
                return null;
            }
        }

        public async Task<bool> DownloadUpdatesAsync(UpdateManifestDto manifest, string appPath)
        {
            if (manifest == null) return false;

            try
            {
                Serilog.Log.Information("Güncelleme dosyaları indirilmeye başlanıyor. Versiyon: {Version}", manifest.Version);
                var systemParam = await _systemParameterService.GetSystemParameterAsync();
                string serverUrl = systemParam?.UpdatePath;

                if (string.IsNullOrWhiteSpace(serverUrl))
                {
                    Serilog.Log.Warning("Güncelleme yolu (UpdatePath) tanımlı değil, indirme işlemi iptal edildi.");
                    return false;
                }

                bool isHttp = serverUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                              serverUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
                string tempFolder = Path.Combine(appPath, "Temp", "UpdateCache");

                if (Directory.Exists(tempFolder)) Directory.Delete(tempFolder, true);
                Directory.CreateDirectory(tempFolder);

                // Download files
                if (manifest.Files != null)
                {
                    foreach (var mf in manifest.Files)
                    {
                        if (string.IsNullOrWhiteSpace(mf.Path)) continue;

                        string relativePath = mf.Path.Replace('/', Path.DirectorySeparatorChar);
                        string localPath = Path.Combine(appPath, relativePath);
                        string tempPath = Path.Combine(tempFolder, relativePath);

                        bool shouldDownload = true;
                        if (File.Exists(localPath))
                        {
                            string localHash = ComputeSha256Hash(localPath);
                            if (localHash.Equals(mf.Hash, StringComparison.OrdinalIgnoreCase))
                            {
                                shouldDownload = false;
                            }
                        }

                        if (shouldDownload)
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

                            string sourcePath = isHttp
                                ? (serverUrl.EndsWith("/") ? serverUrl : serverUrl + "/") + mf.Path
                                : Path.Combine(serverUrl, relativePath);

                            if (isHttp)
                            {
                                using (var http = new HttpClient())
                                {
                                    var response = await http.GetAsync(sourcePath);
                                    response.EnsureSuccessStatusCode();
                                    using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
                                    {
                                        await response.Content.CopyToAsync(fs);
                                    }
                                }
                            }
                            else
                            {
                                if (File.Exists(sourcePath))
                                    File.Copy(sourcePath, tempPath, true);
                            }
                        }
                    }
                }

                // Save manifest to temp folder to let Updater know what's ready
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                };
                string json = JsonSerializer.Serialize(manifest, options);
                File.WriteAllText(Path.Combine(tempFolder, "update_manifest.json"), json);

                Serilog.Log.Information("Güncelleme paketleri başarıyla Temp klasörüne indirildi.");
                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "DownloadUpdatesAsync sırasında bir hata oluştu.");
                return false;
            }
        }

        public bool IsUpdateReady(string appPath, out UpdateManifestDto manifest)
        {
            manifest = null;
            string tempFolder = Path.Combine(appPath, "Temp", "UpdateCache");
            string manifestPath = Path.Combine(tempFolder, "update_manifest.json");

            if (!File.Exists(manifestPath)) return false;

            try
            {
                string json = File.ReadAllText(manifestPath);
                if (string.IsNullOrWhiteSpace(json)) return false;

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                };
                manifest = JsonSerializer.Deserialize<UpdateManifestDto>(json, options);

                return manifest != null;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetUpdateServerUrlAsync()
        {
            var systemParam = await _systemParameterService.GetSystemParameterAsync();
            return systemParam?.UpdatePath ?? "";
        }

        private string ComputeSha256Hash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}


