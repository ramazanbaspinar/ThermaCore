using System.Diagnostics;

namespace WinBeyazEsya.Updater;

static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        // Self-Update & File-Lock Çözümü
        // Updater doğrudan ana klasörden çalıştırılırsa, kendi kendini ezemez (File-Lock).
        // Bu yüzden kendini %TEMP% klasörüne kopyalar ve oradan çalıştırır.

        bool runFromTemp = false;
        string targetAppPath = AppDomain.CurrentDomain.BaseDirectory;
        string serverUrl = "";

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--run-from-temp" && i + 1 < args.Length)
            {
                runFromTemp = true;
                targetAppPath = args[i + 1];
            }
            if (args[i] == "--url" && i + 1 < args.Length)
            {
                serverUrl = args[i + 1];
            }
        }

        if (!runFromTemp)
        {
            // Orijinal exe dosya yolu
            string exePath = Application.ExecutablePath;
            string tempDir = Path.Combine(Path.GetTempPath(), "WinBeyazEsya.Updater");
            string tempExePath = Path.Combine(tempDir, Path.GetFileName(exePath));

            try
            {
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                // Eski temp dosyasını temizle (varsa)
                if (File.Exists(tempExePath))
                {
                    try { File.Delete(tempExePath); } catch { }
                }

                // dll'leri de kopyalamak gerekebilir ama Windows Forms tek bir exe olarak publish edildiyse
                // sadece exe'yi kopyalamak yeterli. Biz tüm dosyaları kopyalayalım.
                string[] filesToCopy = Directory.GetFiles(targetAppPath, "WinBeyazEsya.Updater.*");
                foreach (var file in filesToCopy)
                {
                    string destFile = Path.Combine(tempDir, Path.GetFileName(file));
                    File.Copy(file, destFile, true);
                }

                // Kopyalanan exe'yi çalıştır
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempExePath,
                    Arguments = $"--run-from-temp \"{targetAppPath.TrimEnd('\\')}\" --url \"{serverUrl}\"",
                    UseShellExecute = true
                };
                Process.Start(psi);

                // Orijinal updater kapansın ki üzerine yazılabilsin
                Application.Exit();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Updater başlatılırken hata oluştu: {ex.Message}");
                return;
            }
        }

        Application.Run(new UpdateForm(targetAppPath, serverUrl));
    }
}
