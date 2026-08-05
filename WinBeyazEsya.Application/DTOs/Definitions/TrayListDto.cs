using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class TrayListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public TrayType? TrayType { get; set; }
    public string TrayTypeName { get; set; } = string.Empty;
    
    public CoatingType? CoatingType { get; set; }
    public string CoatingTypeName { get; set; } = string.Empty;
    
    public decimal? WidthMm { get; set; }
    public decimal? DepthMm { get; set; }
    public decimal? ThicknessMm { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string SpecialCodeName { get; set; } = string.Empty;
}

