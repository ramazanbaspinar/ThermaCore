namespace WinBeyazEsya.Presentation.WinForms.Models
{
    public class PermissionNodeDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsChecked { get; set; }

        public int ModuleId { get; set; }
        public PermissionType? PermissionType { get; set; }

        public string? SpecialPermissions { get; set; }
    }

    public enum PermissionType
    {
        Read = 1,
        Create = 2,
        Update = 3,
        Delete = 4,
        Special = 5
    }
}

