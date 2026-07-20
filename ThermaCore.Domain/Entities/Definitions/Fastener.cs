using System;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Entities.Production;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Definitions;

public class Fastener : FullAuditableEntity
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public bool IsActive { get; set; } = true;
    
    public FastenerType? FastenerType { get; set; }
    public MaterialType? MaterialType { get; set; }
    
    public decimal? WeightGr { get; set; }
    
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
    
    public long? QualityStandardId { get; set; }
    public virtual QualityStandard? QualityStandard { get; set; }
}
