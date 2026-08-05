using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class FittingDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public FittingType? FittingType { get; set; }
    public MaterialType? MaterialType { get; set; }
    public string? ThreadSize { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
}

