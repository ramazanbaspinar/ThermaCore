using System.ComponentModel.DataAnnotations.Schema;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Management;

public class UserBranch : FullAuditableEntity
{
    public long UserId { get; set; }
    public long BranchId { get; set; }
    
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("BranchId")]
    public virtual Branch Branch { get; set; }
}
