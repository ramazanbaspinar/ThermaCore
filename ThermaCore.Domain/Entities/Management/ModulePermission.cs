using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Management;

public class ModulePermission : AuditableEntity
{
    public long UserRoleId { get; set; }
    public ModuleType Module { get; set; }
    
    public byte CanView { get; set; }
    public byte CanAdd { get; set; }
    public byte CanEdit { get; set; }
    public byte CanDelete { get; set; }

    public virtual UserRole UserRole { get; set; } = null!;
}
