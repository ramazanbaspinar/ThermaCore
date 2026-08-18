using System.Security.Cryptography;
using System.Text.Json;

namespace WinBeyazEsya.ManifestBuilder
{
    class Program
    {
        // Kara Liste: Bu dosya/uzantı/klasörler manifest'e eklenmez ve hedefe kopyalanmaz
        private static readonly HashSet<string> _blacklistExactFiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "license.lic",
            "update_config.json",
            "update_manifest.json"
        };

        private static readonly string[] _blacklistExtensions = { ".pdb", ".xml", ".config" };

        private static readonly string[] _blacklistPrefixes = { "logs\\", "logs/", "temp\\", "temp/", "update_backups\\", "update_backups/" };

        private static bool IsBlacklisted(string relativePath)
        {
            string fileName = Path.GetFileName(relativePath);
            if (_blacklistExactFiles.Contains(fileName)) return true;
            if (_blacklistExtensions.Any(ext => relativePath.EndsWith(ext, StringComparison.OrdinalIgnoreCase))) return true;
            if (_blacklistPrefixes.Any(p => relativePath.StartsWith(p, StringComparison.OrdinalIgnoreCase))) return true;
            return false;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== WinBeyazEsya.ManifestBuilder (Paketleyici) ===");

                string sourceDir = null;
                string version = null;
                string outputDir = null;
                bool isCritical = false;
                List<string> notes = new List<string>();

                if (args.Length > 0 && !args.Contains("--help") && !args.Contains("-h"))
                {
                    // Komut Satırı Modu
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i] == "--source" && i + 1 < args.Length) sourceDir = args[++i];
                        else if (args[i] == "--version" && i + 1 < args.Length) version = args[++i];
                        else if (args[i] == "--output" && i + 1 < args.Length) outputDir = args[++i];
                        else if (args[i] == "--critical" && i + 1 < args.Length) isCritical = bool.Parse(args[++i]);
                        else if (args[i] == "--notes" && i + 1 < args.Length)
                        {
                            string notesRaw = args[++i];
                            notes = notesRaw.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim()).ToList();
                        }
                    }
                }
                else
                {
                    // İnteraktif Mod (Kullanıcı Çift Tıkladığında)
                    Console.WriteLine("Lütfen paketlenecek dosyaların bulunduğu Kaynak Klasörü girin:");
                    sourceDir = GetCleanPathFromConsole();

                    Console.WriteLine("\nYeni Versiyon Numarasını girin (Örn: 1.0.5.0):");
                    version = Console.ReadLine()?.Trim();

                    Console.WriteLine("\nManifest ve Çıktı Dosyalarının kaydedileceği Hedef Klasörü girin:");
                    outputDir = GetCleanPathFromConsole();

                    Console.WriteLine("\nBu zorunlu/kritik bir güncelleme mi? (E/H):");
                    string criticalInput = Console.ReadLine()?.Trim().ToUpper();
                    isCritical = criticalInput == "E";

                    Console.WriteLine("\nSürüm Notları (İsteğe bağlı, her notu | ile ayırın):");
                    string notesRaw = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(notesRaw))
                    {
                        notes = notesRaw.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim()).ToList();
                    }
                }

                if (string.IsNullOrEmpty(sourceDir) || string.IsNullOrEmpty(version) || string.IsNullOrEmpty(outputDir))
                {
                    Console.WriteLine("\nHATA: Kaynak Klasör, Versiyon ve Hedef Klasör bilgileri zorunludur!");
                    return;
                }

                if (!Directory.Exists(sourceDir))
                {
                    Console.WriteLine($"\nHATA: Kaynak klasör bulunamadı: {sourceDir}");
                    return;
                }

                // Kaynak ve hedef aynı klasörse kopyalama yapma (güvenlik kontrolü)
                string normalizedSource = Path.GetFullPath(sourceDir).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                string normalizedOutput = Path.GetFullPath(outputDir).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                bool isSameDirectory = string.Equals(normalizedSource, normalizedOutput, StringComparison.OrdinalIgnoreCase);

                if (isSameDirectory)
                {
                    Console.WriteLine("\nUYARI: Kaynak ve hedef klasör aynı! Dosyalar kopyalanmayacak, sadece manifest oluşturulacak.");
                }

                Console.WriteLine("\nPaketleme işlemi başlatılıyor...");
                var manifest = new UpdateManifest
                {
                    Version = version,
                    IsCritical = isCritical,
                    ReleaseNotes = notes,
                    Files = new List<ManifestFile>()
                };

                var files = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);
                Console.WriteLine($"{files.Length} dosya tarandı, Kara Liste filtreleniyor ve Hash'ler hesaplanıyor...");

                int copyCount = 0;
                int skippedCount = 0;
                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    string relativePath = GetRelativePath(sourceDir, file).Replace('\\', '/');

                    // Kara Liste kontrolü
                    if (IsBlacklisted(relativePath))
                    {
                        skippedCount++;
                        continue;
                    }

                    string hash = ComputeSha256Hash(file);
                    manifest.Files.Add(new ManifestFile
                    {
                        Path = relativePath,
                        Hash = hash,
                        Size = fileInfo.Length
                    });

                    // Dosyayı hedef klasöre fiziksel olarak kopyala (klasör yapısını koru)
                    if (!isSameDirectory)
                    {
                        string destPath = Path.Combine(outputDir, relativePath.Replace('/', Path.DirectorySeparatorChar));
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath)!);
                        File.Copy(file, destPath, true);
                    }
                    copyCount++;

                    Console.Write($"\r  İşleniyor: {copyCount}/{files.Length - skippedCount}");
                }

                Console.WriteLine(); // Yeni satıra geç

                if (!Directory.Exists(outputDir))
                    Directory.CreateDirectory(outputDir);

                string manifestPath = Path.Combine(outputDir, "update_manifest.json");

                var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string json = JsonSerializer.Serialize(manifest, options);

                File.WriteAllText(manifestPath, json);

                Console.WriteLine($"\nBAŞARILI: {manifest.Files.Count} dosya işlendi, {skippedCount} dosya Kara Liste ile atlandı.");
                if (!isSameDirectory)
                    Console.WriteLine($"Dosyalar hedefe kopyalandı: {outputDir}");
                Console.WriteLine($"Manifest oluşturuldu: {manifestPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nBEKLENMEYEN BİR HATA OLUŞTU:\n{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                // Çökme sorununu çözmek için son bekletme
                Console.WriteLine("\nÇıkmak için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        // Tırnak işaretlerini ve hatalı yolları temizleyen güvenli okuma metodu
        static string GetCleanPathFromConsole()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return "";

            // Kullanıcının kopyaladığı yoldaki tırnakları (") temizle
            input = input.Trim().Trim('\"', '\'');
            return input;
        }

        static string ComputeSha256Hash(string filePath)
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

        static string GetRelativePath(string rootPath, string fullPath)
        {
            if (!rootPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                rootPath += Path.DirectorySeparatorChar;

            if (fullPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
                return fullPath.Substring(rootPath.Length);

            return fullPath;
        }
    }

    class UpdateManifest
    {
        public string Version { get; set; }
        public bool IsCritical { get; set; }
        public List<string> ReleaseNotes { get; set; }
        public List<ManifestFile> Files { get; set; }
    }

    class ManifestFile
    {
        public string Path { get; set; }
        public string Hash { get; set; }
        public long Size { get; set; }
    }
}
