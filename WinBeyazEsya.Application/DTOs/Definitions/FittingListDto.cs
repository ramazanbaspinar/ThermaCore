using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class FittingListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public FittingType? FittingType { get; set; }
    public string FittingTypeName { get; set; } = string.Empty;
    public MaterialType? MaterialType { get; set; }
    public string MaterialTypeName { get; set; } = string.Empty;
    public string? ThreadSize { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
    public string SpecialCodeName { get; set; } = string.Empty;
}

