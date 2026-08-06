using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBeyazEsya.Updater
{
    public partial class UpdateForm : Form
    {
        private string _appPath;
        private string _serverUrl;
        private string _tempFolder;
        private string _backupFolder;
        private List<string> _addedFiles = new List<string>();
        
        // Akıllı Temizlik ve İstisna Listesi (Kara Liste)
        private readonly HashSet<string> _exclusionExactMatches = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "license.lic",
            "update_config.json"
        };
        private readonly string[] _exclusionPrefixes = { "logs\\", "logs/", "temp\\", "temp/", "update_backups\\", "update_backups/" };
        private readonly string[] _exclusionExtensions = { ".config" };

        public UpdateForm(string appPath, string serverUrl)
        {
            InitializeComponent();

            _appPath = string.IsNullOrWhiteSpace(appPath) ? AppDomain.CurrentDomain.BaseDirectory : appPath;
            _serverUrl = serverUrl?.TrimEnd('/', '\\') ?? "";
            _tempFolder = Path.Combine(_appPath, "Temp", "UpdateCache");
            _backupFolder = Path.Combine(_appPath, "Temp", "Backup");
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            if (string.IsNullOrWhiteSpace(_serverUrl))
            {
                MessageBox.Show("Güncelleme sunucu adresi (URL) belirtilmemiş!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            await PerformUpdateAsync();
        }

        private void UpdateStatus(string message, int progress)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateStatus(message, progress)));
                return;
            }
            this._lblStatus.Text = message;
            if (progress >= 0 && progress <= 100)
                this._progressBar.Value = progress;
        }

        private bool IsExcluded(string relativePath)
        {
            if (_exclusionExactMatches.Contains(relativePath)) return true;
            if (_exclusionPrefixes.Any(p => relativePath.StartsWith(p, StringComparison.OrdinalIgnoreCase))) return true;
            if (_exclusionExtensions.Any(ext => relativePath.EndsWith(ext, StringComparison.OrdinalIgnoreCase))) return true;
            return false;
        }

        private async Task PerformUpdateAsync()
        {
            try
            {
                UpdateStatus("Uygulamanın kapanması bekleniyor...", 5);
                await GracefulKillAppAsync("WinBeyazEsya.Presentation.WinForms");

                // Temp klasörünü hazırla
                if (Directory.Exists(_tempFolder))
                {
                    try { Directory.Delete(_tempFolder, true); } catch { }
                }
                Directory.CreateDirectory(_tempFolder);

                string manifestTempPath = Path.Combine(_tempFolder, "update_manifest.json");

                bool isCloud = _serverUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || 
                               _serverUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

                if (isCloud)
                {
                    UpdateStatus("Bulut sunucusundan manifest indiriliyor...", 10);
                    using (HttpClient client = new HttpClient())
                    {
                        string manifestUrl = _serverUrl + "/update_manifest.json";
                        await DownloadFileAsync(client, manifestUrl, manifestTempPath);
                    }
                }
                else
                {
                    UpdateStatus("Yerel ağdan manifest kopyalanıyor...", 10);
                    string manifestLocalPath = Path.Combine(_serverUrl, "update_manifest.json");
                    if (!File.Exists(manifestLocalPath))
                    {
                        throw new Exception($"Yerel sunucuda manifest bulunamadı: {manifestLocalPath}");
                    }
                    File.Copy(manifestLocalPath, manifestTempPath, true);
                }

                string json = File.ReadAllText(manifestTempPath);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var manifest = JsonSerializer.Deserialize<UpdateManifestDto>(json, options);
                
                if (manifest == null || manifest.Files == null || manifest.Files.Count == 0)
                {
                    throw new Exception("Güncelleme manifest dosyası geçersiz veya boş!");
                }

                // Download/Copy Files
                int count = 0;
                using (HttpClient client = isCloud ? new HttpClient() : null)
                {
                    foreach (var mf in manifest.Files)
                    {
                        string relativePath = mf.Path.Replace('/', Path.DirectorySeparatorChar);
                        
                        // Exclusion list kontrolü
                        if (IsExcluded(relativePath)) continue;

                        string tempPath = Path.Combine(_tempFolder, relativePath);
                        Directory.CreateDirectory(Path.GetDirectoryName(tempPath)!);

                        if (isCloud)
                        {
                            UpdateStatus($"Buluttan indiriliyor... ({count + 1}/{manifest.Files.Count})", 15 + (20 * count / manifest.Files.Count));
                            string fileUrl = _serverUrl + "/" + mf.Path.Replace('\\', '/');
                            await DownloadFileAsync(client, fileUrl, tempPath);
                        }
                        else
                        {
                            UpdateStatus($"Yerel ağdan kopyalanıyor... ({count + 1}/{manifest.Files.Count})", 15 + (20 * count / manifest.Files.Count));
                            string sourcePath = Path.Combine(_serverUrl, relativePath);
                            if (File.Exists(sourcePath))
                            {
                                File.Copy(sourcePath, tempPath, true);
                            }
                            else
                            {
                                throw new Exception($"Yerel sunucuda dosya bulunamadı: {sourcePath}");
                            }
                        }

                        count++;
                    }
                }

                UpdateStatus("Dosya bütünlükleri (SHA256) kontrol ediliyor...", 40);
                foreach (var mf in manifest.Files)
                {
                    string relativePath = mf.Path.Replace('/', Path.DirectorySeparatorChar);
                    if (IsExcluded(relativePath)) continue;

                    string tempPath = Path.Combine(_tempFolder, relativePath);
                    if (File.Exists(tempPath))
                    {
                        string localHash = CalculateSHA256(tempPath);
                        if (!string.Equals(localHash, mf.Hash, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new Exception($"'{relativePath}' dosyasının bütünlüğü doğrulanamadı (SHA256 uyuşmazlığı)! İndirme işlemi bozulmuş olabilir.");
                        }
                    }
                    else
                    {
                        throw new Exception($"'{relativePath}' güncelleme paketi içinde bulunamadı!");
                    }
                }

                UpdateStatus("Yedekleme alınıyor...", 50);
                if (Directory.Exists(_backupFolder)) Directory.Delete(_backupFolder, true);
                Directory.CreateDirectory(_backupFolder);

                var filesToUpdate = manifest.Files
                    .Select(mf => mf.Path.Replace('/', Path.DirectorySeparatorChar))
                    .Where(p => !IsExcluded(p))
                    .ToList();

                foreach (var relativePath in filesToUpdate)
                {
                    string localPath = Path.Combine(_appPath, relativePath);
                    string backupPath = Path.Combine(_backupFolder, relativePath);

                    if (File.Exists(localPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(backupPath)!);
                        File.Copy(localPath, backupPath, true);
                    }
                }

                UpdateStatus("Yeni dosyalar sisteme entegre ediliyor...", 65);
                count = 0;
                foreach (var relativePath in filesToUpdate)
                {
                    string localPath = Path.Combine(_appPath, relativePath);
                    string tempPath = Path.Combine(_tempFolder, relativePath);

                    bool fileExistedBefore = File.Exists(localPath);
                    
                    Directory.CreateDirectory(Path.GetDirectoryName(localPath)!);
                    
                    bool copied = false;
                    for (int i = 0; i < 5; i++)
                    {
                        try
                        {
                            File.Copy(tempPath, localPath, true);
                            copied = true;
                            if (!fileExistedBefore)
                            {
                                _addedFiles.Add(localPath);
                            }
                            break;
                        }
                        catch (IOException)
                        {
                            await GracefulKillAppAsync("WinBeyazEsya.Presentation.WinForms", true);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            await GracefulKillAppAsync("WinBeyazEsya.Presentation.WinForms", true);
                        }
                    }
                    
                    if (!copied)
                    {
                        throw new Exception($"'{relativePath}' dosyası kilitli olduğu için kopyalanamadı.");
                    }
                    
                    count++;
                    UpdateStatus($"Sisteme entegre ediliyor... ({count}/{filesToUpdate.Count})", 65 + (25 * count / filesToUpdate.Count));
                }

                UpdateStatus("Güncelleme tamamlandı, program başlatılıyor...", 95);
                
                // Temizlik
                try { Directory.Delete(_tempFolder, true); } catch { }

                // ERP'yi yeniden başlat
                string exePath = Path.Combine(_appPath, "WinBeyazEsya.Presentation.WinForms.exe");
                if (File.Exists(exePath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = exePath,
                        WorkingDirectory = _appPath
                    });
                }

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme başarısız oldu. Değişiklikler geri alınıyor...\n\nHata: {ex.Message}", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Rollback();
                Application.Exit();
            }
        }

        private async Task DownloadFileAsync(HttpClient client, string url, string destPath)
        {
            using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                using (var fs = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fs);
                }
            }
        }

        private void Rollback()
        {
            try
            {
                UpdateStatus("Geri alma (Rollback) işlemi başlatıldı...", 0);
                
                // Yeni eklenen dosyaları sil
                foreach (var addedFile in _addedFiles)
                {
                    if (File.Exists(addedFile))
                    {
                        try { File.Delete(addedFile); } catch { }
                    }
                }

                // Yedeklenenleri geri kopyala
                if (Directory.Exists(_backupFolder))
                {
                    var files = Directory.GetFiles(_backupFolder, "*.*", SearchOption.AllDirectories);
                    foreach (var backupFile in files)
                    {
                        string relativePath = backupFile.Substring(_backupFolder.Length + 1);
                        string localPath = Path.Combine(_appPath, relativePath);
                        try
                        {
                            File.Copy(backupFile, localPath, true);
                        }
                        catch { }
                    }
                }
                
                MessageBox.Show("Sistem eski kararlı sürüme geri döndürüldü.", "Rollback Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kritik Geri Alma (Rollback) Hatası: {ex.Message}\nSistem manuel onarım gerektirebilir.", "Felaket Kurtarma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GracefulKillAppAsync(string processName, bool forceKill = false)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0) return;

            foreach (var p in processes)
            {
                try
                {
                    if (!forceKill)
                    {
                        p.CloseMainWindow();
                    }
                }
                catch { }
            }

            if (!forceKill)
            {
                await Task.Delay(3000); // Kapanmasını bekle
            }

            processes = Process.GetProcessesByName(processName);
            foreach (var p in processes)
            {
                try
                {
                    p.Kill();
                    p.WaitForExit(2000);
                }
                catch { }
            }
        }

        private string CalculateSHA256(string filePath)
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

    class UpdateManifestDto
    {
        public string Version { get; set; }
        public bool IsCritical { get; set; }
        public List<string> ReleaseNotes { get; set; }
        public List<ManifestFileDto> Files { get; set; }
    }

    class ManifestFileDto
    {
        public string Path { get; set; }
        public string Hash { get; set; }
        public long Size { get; set; }
    }
}
