using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;

namespace WinBeyazEsya.ManifestBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Contains("--help") || args.Contains("-h"))
            {
                Console.WriteLine("Kullanım: WinBeyazEsya.ManifestBuilder --source <yol> --version <sürüm> --output <yol> [--critical true/false] [--notes \"not1|not2\"]");
                return;
            }

            string sourceDir = null;
            string version = null;
            string outputDir = null;
            bool isCritical = false;
            List<string> notes = new List<string>();

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

            if (string.IsNullOrEmpty(sourceDir) || string.IsNullOrEmpty(version) || string.IsNullOrEmpty(outputDir))
            {
                Console.WriteLine("Hata: --source, --version ve --output zorunludur.");
                Environment.Exit(1);
            }

            if (!Directory.Exists(sourceDir))
            {
                Console.WriteLine($"Hata: Kaynak klasör bulunamadı: {sourceDir}");
                Environment.Exit(1);
            }

            var manifest = new UpdateManifest
            {
                Version = version,
                IsCritical = isCritical,
                ReleaseNotes = notes,
                Files = new List<ManifestFile>()
            };

            var files = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                // Gereksiz dosyaları atla (manifest ve eski updater artıkları vb.)
                if (file.EndsWith("update_manifest.json", StringComparison.OrdinalIgnoreCase)) continue;

                var fileInfo = new FileInfo(file);
                string relativePath = GetRelativePath(sourceDir, file).Replace('\\', '/');

                manifest.Files.Add(new ManifestFile
                {
                    Path = relativePath,
                    Hash = ComputeSha256Hash(file),
                    Size = fileInfo.Length
                });
            }

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string manifestPath = Path.Combine(outputDir, "update_manifest.json");

            var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            string json = JsonSerializer.Serialize(manifest, options);

            File.WriteAllText(manifestPath, json);

            Console.WriteLine($"Manifest başarıyla oluşturuldu: {manifestPath}");
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

