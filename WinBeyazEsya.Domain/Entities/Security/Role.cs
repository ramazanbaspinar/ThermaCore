using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Security;

public class Role : FullAuditableEntity
{
    public string Code { get; set; } = null!;
    public string RoleName { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<RolePermission> Permissions { get; set; } = new HashSet<RolePermission>();
}

