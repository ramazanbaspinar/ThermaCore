using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class FinishedGood : FullAuditableEntity, IMustHaveBranch
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    
    public WinBeyazEsya.Domain.Enums.FinishedGoodGroupType GroupType { get; set; }

    public long UnitId { get; set; }
    public virtual Unit Unit { get; set; } = null!;

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }

    public decimal SalesPrice { get; set; }
    public decimal SalesVatRate { get; set; }

    public string? Description { get; set; }

    public long BranchId { get; set; }
    public bool IsActive { get; set; } = true;
}
