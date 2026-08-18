using System.ComponentModel.DataAnnotations.Schema;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

public class UserTenant : FullAuditableEntity
{
    public long UserId { get; set; }
    public long TenantDatabaseId { get; set; }

    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("TenantDatabaseId")]
    public virtual TenantDatabase TenantDatabase { get; set; }
}

