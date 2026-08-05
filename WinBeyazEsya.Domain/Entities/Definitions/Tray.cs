using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class Tray : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public TrayType? TrayType { get; set; }
    public CoatingType? CoatingType { get; set; }
    
    public decimal? WidthMm { get; set; }
    public decimal? DepthMm { get; set; }
    public decimal? ThicknessMm { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}

