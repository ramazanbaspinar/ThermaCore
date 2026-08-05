using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Domain.Entities.Security;

public class UserPermission : Entity
{
    public long UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public int ModuleId { get; set; } // Can be casted to/from ModuleType
    public int ParentId { get; set; }
    public string ModuleName { get; set; } = null!;

    public bool CanRead { get; set; }
    public bool CanCreate { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }

    public string? SpecialPermissions { get; set; }
}

