using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBeyazEsya.Updater
{
    public partial class UpdateForm : Form
    {
        private string _appPath;
        private string _tempFolder;
        private string _backupFolder;

        public UpdateForm()
        {
            InitializeComponent();

            _appPath = AppDomain.CurrentDomain.BaseDirectory;
            
            // Eğer Updater, WinBeyazEsya ile aynı dizinde değilse (örn. geliştirme ortamı), 
            // args veya Parent process üzerinden appPath alınabilir. Şimdilik aynı dizinde varsayıyoruz.
            _tempFolder = Path.Combine(_appPath, "Temp", "UpdateCache");
            _backupFolder = Path.Combine(_appPath, "Temp", "Backup");
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await PerformUpdateAsync();
        }

        private void UpdateStatus(string message, int progress)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateStatus(message, progress)));
                return;
            }
            _lblStatus.Text = message;
            _progressBar.Value = progress;
        }

        private async Task PerformUpdateAsync()
        {
            try
            {
                UpdateStatus("Uygulamanın kapanması bekleniyor...", 10);
                await Task.Delay(2000); // Ana uygulamanın tamamen kapanması için bekle

                KillApp("WinBeyazEsya.Presentation.WinForms"); // Gerekirse zorla kapat

                string manifestPath = Path.Combine(_tempFolder, "update_manifest.json");
                if (!File.Exists(manifestPath))
                {
                    MessageBox.Show("Güncelleme dosyaları bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                string json = File.ReadAllText(manifestPath);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var manifest = JsonSerializer.Deserialize<UpdateManifestDto>(json, options);

                UpdateStatus("Yedekleme alınıyor...", 30);
                if (Directory.Exists(_backupFolder)) Directory.Delete(_backupFolder, true);
                Directory.CreateDirectory(_backupFolder);

                var backupItems = new List<string>();

                // Yedekleme işlemi
                foreach (var mf in manifest.Files)
                {
                    string relativePath = mf.Path.Replace('/', Path.DirectorySeparatorChar);
                    string localPath = Path.Combine(_appPath, relativePath);
                    string backupPath = Path.Combine(_backupFolder, relativePath);

                    if (File.Exists(localPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(backupPath));
                        File.Copy(localPath, backupPath, true);
                        backupItems.Add(relativePath);
                    }
                }

                UpdateStatus("Yeni dosyalar kopyalanıyor...", 60);
                int count = 0;
                foreach (var mf in manifest.Files)
                {
                    string relativePath = mf.Path.Replace('/', Path.DirectorySeparatorChar);
                    string localPath = Path.Combine(_appPath, relativePath);
                    string tempPath = Path.Combine(_tempFolder, relativePath);

                    if (File.Exists(tempPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                        
                        bool copied = false;
                        for (int i = 0; i < 5; i++)
                        {
                            try
                            {
                                File.Copy(tempPath, localPath, true);
                                copied = true;
                                break;
                            }
                            catch (IOException)
                            {
                                KillApp("WinBeyazEsya.Presentation.WinForms");
                                await Task.Delay(1000);
                            }
                            catch (UnauthorizedAccessException)
                            {
                                KillApp("WinBeyazEsya.Presentation.WinForms");
                                await Task.Delay(1000);
                            }
                        }
                        
                        if (!copied)
                        {
                            throw new Exception($"'{relativePath}' dosyası kilitli olduğu için kopyalanamadı.");
                        }
                    }
                    count++;
                    UpdateStatus($"Dosyalar kopyalanıyor... ({count}/{manifest.Files.Count})", 60 + (30 * count / manifest.Files.Count));
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
                MessageBox.Show($"Güncelleme sırasında hata oluştu. Değişiklikler geri alınıyor...\n\nHata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Rollback();
                Application.Exit();
            }
        }

        private void Rollback()
        {
            try
            {
                UpdateStatus("Değişiklikler geri alınıyor...", 0);
                if (Directory.Exists(_backupFolder))
                {
                    var files = Directory.GetFiles(_backupFolder, "*.*", SearchOption.AllDirectories);
                    foreach (var backupFile in files)
                    {
                        string relativePath = backupFile.Substring(_backupFolder.Length + 1);
                        string localPath = Path.Combine(_appPath, relativePath);
                        File.Copy(backupFile, localPath, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Geri alma işlemi başarısız: {ex.Message}");
            }
        }

        private void KillApp(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            foreach (var p in processes)
            {
                try
                {
                    p.Kill();
                    p.WaitForExit();
                }
                catch { }
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

