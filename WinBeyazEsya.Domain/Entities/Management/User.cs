using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

public class User : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Email { get; set; }

    public virtual ICollection<UserTenant> UserTenants { get; set; } = new List<UserTenant>();

    public virtual ICollection<UserBranch> UserBranches { get; set; } = new List<UserBranch>();

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public long UserRoleId { get; set; }

    public virtual WinBeyazEsya.Domain.Entities.Security.Role Role { get; set; } = null!;
}

