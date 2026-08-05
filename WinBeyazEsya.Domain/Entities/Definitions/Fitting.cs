using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class Fitting : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    
    public FittingType? FittingType { get; set; }
    public MaterialType? MaterialType { get; set; }
    public string? ThreadSize { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}

