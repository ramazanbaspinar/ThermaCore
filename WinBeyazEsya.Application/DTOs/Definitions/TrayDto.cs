using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class TrayDto : BaseDto
{
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
}

