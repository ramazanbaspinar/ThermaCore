using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class PlasticAndVisualPartsGroup : FullAuditableEntity, IMustHaveBranch
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    
    public long BaseUnitId { get; set; }
    public virtual Unit BaseUnit { get; set; } = null!;

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }

    public string? MaterialType { get; set; }

    public string? Description { get; set; }

    public long BranchId { get; set; }
    public bool IsActive { get; set; } = true;
}


