using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Definitions;

public class PackagingMaterial : FullAuditableEntity
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public bool IsActive { get; set; } = true;
    
    public PackagingType? PackagingType { get; set; }
    public PackagingMaterialType? PackagingMaterialType { get; set; }
    
    public decimal? ThicknessMm { get; set; }
    public decimal? WeightGr { get; set; }
    
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}
