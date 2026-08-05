using System;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Entities.Production;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Definitions;

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

