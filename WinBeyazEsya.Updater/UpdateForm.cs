using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.Json;

namespace WinBeyazEsya.Updater
{
    public partial class UpdateForm : Form
    {
        private string _appPath;
        private string _serverUrl;
        private string _tempFolder;
        private string _backupFolder;
        private List<string> _addedFiles = new List<string>();

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

            await Task.Run(async () => await PerformUpdateWorkerAsync());
        }

        private void UpdateStatus(string message, int progress)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdateStatus(message, progress)));
                return;
            }
            this._lblStatus.Text = message;
            if (progress >= 0 && progress <= 100)
            {
                this._progressBar.Value = progress;
                this.lblPercent.Text = $"%{progress}";
            }
        }

        private bool IsExcluded(string relativePath)
        {
            if (_exclusionExactMatches.Contains(relativePath)) return true;
            if (_exclusionPrefixes.Any(p => relativePath.StartsWith(p, StringComparison.OrdinalIgnoreCase))) return true;
            if (_exclusionExtensions.Any(ext => relativePath.EndsWith(ext, StringComparison.OrdinalIgnoreCase))) return true;
            return false;
        }

        private async Task PerformUpdateWorkerAsync()
        {
            bool success = false;
            try
            {
                UpdateStatus("Uygulamanın kapanması bekleniyor...", 5);
                await GracefulKillAppAsync("WinBeyazEsya");

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
                    UpdateStatus("☁️ Bulut sunucusundan manifest indiriliyor...", 8);
                    using (HttpClient client = new HttpClient())
                    {
                        string manifestUrl = _serverUrl + "/update_manifest.json";
                        await DownloadFileAsync(client, manifestUrl, manifestTempPath);
                    }
                }
                else
                {
                    UpdateStatus("🌐 Yerel ağdan manifest kopyalanıyor...", 8);
                    string manifestLocalPath = Path.Combine(_serverUrl, "update_manifest.json");
                    if (!File.Exists(manifestLocalPath))
                    {
                        throw new Exception($"Yerel sunucuda manifest bulunamadı:\n{manifestLocalPath}");
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

                // ADIM 1: İndirme / Kopyalama
                int count = 0;
                int totalFiles = manifest.Files.Count;
                using (HttpClient client = isCloud ? new HttpClient() : null)
                {
                    foreach (var mf in manifest.Files)
                    {
                        string relativePath = mf.Path.Replace('/', Path.DirectorySeparatorChar);
                        if (IsExcluded(relativePath)) { count++; continue; }

                        string tempPath = Path.Combine(_tempFolder, relativePath);
                        Directory.CreateDirectory(Path.GetDirectoryName(tempPath)!);

                        if (isCloud)
                        {
                            UpdateStatus($"☁️ Buluttan indiriliyor... ({count + 1}/{totalFiles})", 10 + (20 * count / totalFiles));
                            string fileUrl = _serverUrl + "/" + mf.Path.Replace('\\', '/');
                            await DownloadFileAsync(client, fileUrl, tempPath);
                        }
                        else
                        {
                            UpdateStatus($"📁 Yerel ağdan kopyalanıyor... ({count + 1}/{totalFiles})", 10 + (20 * count / totalFiles));
                            string sourcePath = Path.Combine(_serverUrl, relativePath);
                            if (File.Exists(sourcePath))
                            {
                                File.Copy(sourcePath, tempPath, true);
                            }
                            else
                            {
                                throw new Exception($"Yerel sunucuda dosya bulunamadı:\n{sourcePath}");
                            }
                        }
                        count++;
                    }
                }

                // ADIM 2: SHA256 Doğrulama
                UpdateStatus("🔒 Dosya bütünlükleri (SHA256) doğrulanıyor...", 35);
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
                            throw new Exception($"'{relativePath}' dosyasının bütünlüğü doğrulanamadı!\n(SHA256 uyuşmazlığı - İndirme bozulmuş olabilir)");
                        }
                    }
                    else
                    {
                        throw new Exception($"'{relativePath}' güncelleme paketi içinde bulunamadı!");
                    }
                }

                // ADIM 3: Yedekleme
                UpdateStatus("💾 Mevcut dosyalar yedekleniyor...", 45);
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

                // ADIM 4: Entegrasyon
                UpdateStatus("⚙️ Yeni dosyalar sisteme entegre ediliyor...", 55);
                count = 0;
                foreach (var relativePath in filesToUpdate)
                {
                    string localPath = Path.Combine(_appPath, relativePath);
                    string tempPath = Path.Combine(_tempFolder, relativePath);

                    if (!File.Exists(tempPath)) continue;

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
                        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                        {
                            try
                            {
                                // ULTIMATE HACK: Kilitli dosyayı yeniden adlandır (.locked)
                                if (File.Exists(localPath))
                                {
                                    string lockedPath = localPath + ".locked_" + Guid.NewGuid().ToString().Substring(0, 5);
                                    File.Move(localPath, lockedPath);
                                    
                                    File.Copy(tempPath, localPath, true);
                                    copied = true;
                                    break;
                                }
                            }
                            catch
                            {
                                await GracefulKillAppAsync("WinBeyazEsya", true);
                            }
                        }
                    }

                    if (!copied)
                    {
                        throw new Exception($"'{relativePath}' dosyası kilitli olduğu için kopyalanamadı.");
                    }

                    count++;
                    UpdateStatus($"⚙️ Entegre ediliyor... ({count}/{filesToUpdate.Count})", 55 + (35 * count / filesToUpdate.Count));
                }

                UpdateStatus("✅ Güncelleme başarıyla tamamlandı!", 100);
                success = true;

                // Temizlik
                try { Directory.Delete(_tempFolder, true); } catch { }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Güncelleme başarısız oldu. Değişiklikler geri alınıyor...\n\nHata: {ex.Message}", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                Rollback();
            }
            finally
            {
                // Her durumda ERP'yi yeniden başlat ve Updater'ı kapat
                await Task.Delay(1500);

                string exePath = Path.Combine(_appPath, "WinBeyazEsya.exe");

                // 1) DEBUG LOGGING: Yolları kontrol etmek için geçici log
                try
                {
                    string logsDir = Path.Combine(_appPath, "Logs");
                    if (!Directory.Exists(logsDir))
                    {
                        Directory.CreateDirectory(logsDir);
                    }
                    File.AppendAllText(Path.Combine(logsDir, "updater_debug.log"),
                        $"[{DateTime.Now}] _appPath: {_appPath}\r\nexePath: {exePath}\r\nFile.Exists: {File.Exists(exePath)}\r\n");
                }
                catch { }

                if (File.Exists(exePath))
                {
                    try
                    {
                        // 2) UseShellExecute = false kullanıyoruz (ShellExecute asenkronCOM/DDE kullanabilir, erken kapanmada iptal olabilir)
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = exePath,
                            WorkingDirectory = _appPath,
                            UseShellExecute = false
                        });

                        // 3) RACE CONDITION ÖNLEMİ: Uygulamanın ayağa kalkması için kısa bir bekleme
                        await Task.Delay(1000);
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show($"Uygulama başlatılamadı:\nYol: {exePath}\nHata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                else
                {
                    // Dosya hiç yoksa sessizce kapanmasını engelle
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Başlatılacak dosya bulunamadı!\nAranan Yol: {exePath}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }

                this.Invoke(new Action(() => Application.Exit()));
            }
        }

        private async Task DownloadFileAsync(HttpClient client, string url, string destPath)
        {
            var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            using (var fs = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await response.Content.CopyToAsync(fs);
            }
        }

        private void Rollback()
        {
            try
            {
                UpdateStatus("🔄 Geri alma (Rollback) işlemi başlatıldı...", 0);

                foreach (var addedFile in _addedFiles)
                {
                    if (File.Exists(addedFile))
                    {
                        try { File.Delete(addedFile); } catch { }
                    }
                }

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
            }
            catch { }
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
                await Task.Delay(3000);
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

            // PROCESS KILL VE HANDLE RELEASE BEKLEMESİ (Server-Grade Fix)
            for (int i = 0; i < 6; i++)
            {
                if (Process.GetProcessesByName(processName).Length == 0)
                    break;
                await Task.Delay(500);
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
