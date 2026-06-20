using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Security;

public class RolePermission : Entity
{
    public long RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;

    public int ModuleId { get; set; } // Can be casted to/from ModuleType
    public int ParentId { get; set; }
    public string ModuleName { get; set; } = null!;

    public bool CanRead { get; set; }
    public bool CanCreate { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }

    public string? SpecialPermissions { get; set; }
}
