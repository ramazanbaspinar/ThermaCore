using System.Collections.Generic;

namespace WinBeyazEsya.Application.DTOs.Updater
{
    public class UpdateManifestDto
    {
        public string Version { get; set; }
        public bool IsCritical { get; set; }
        public List<string> ReleaseNotes { get; set; }
        public List<ManifestFileDto> Files { get; set; }
    }

    public class ManifestFileDto
    {
        public string Path { get; set; }
        public string Hash { get; set; }
        public long Size { get; set; }
    }
}

