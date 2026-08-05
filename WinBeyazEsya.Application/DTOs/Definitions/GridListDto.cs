using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class GridListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public GridType? GridType { get; set; }
    public string GridTypeName { get; set; } = string.Empty;
    
    public decimal? WidthMm { get; set; }
    public decimal? DepthMm { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string SpecialCodeName { get; set; } = string.Empty;
}

