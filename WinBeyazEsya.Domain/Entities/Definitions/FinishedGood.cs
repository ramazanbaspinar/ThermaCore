using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class FinishedGood : FullAuditableEntity, IMustHaveBranch
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    
    public long? GroupId { get; set; }
    // Add navigation property later if there's a FinishedGoodGroup entity, but the user only mentioned GroupId. We'll leave it as a long? for now.

    public long UnitId { get; set; }
    public virtual Unit Unit { get; set; } = null!;

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }

    public decimal SalesPrice { get; set; }
    public decimal SalesVatRate { get; set; }

    public string? Description { get; set; }
    public byte[]? Picture { get; set; }

    public long BranchId { get; set; }
    public bool IsActive { get; set; } = true;
}
