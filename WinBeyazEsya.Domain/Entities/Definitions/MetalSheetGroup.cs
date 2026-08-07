using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class MetalSheetGroup : FullAuditableEntity, IMustHaveBranch
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    
    public long BaseUnitId { get; set; }
    public virtual Unit BaseUnit { get; set; } = null!;

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }

    public string? SurfaceType { get; set; }
    public string? QualityCode { get; set; }
    
    public decimal Width { get; set; }
    public decimal Length { get; set; }
    public decimal Thickness { get; set; }
    
    public string? Description { get; set; }

    public long BranchId { get; set; }
    public bool IsActive { get; set; } = true;
}
