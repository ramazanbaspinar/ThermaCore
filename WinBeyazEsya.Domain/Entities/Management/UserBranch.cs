using System.ComponentModel.DataAnnotations.Schema;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

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

