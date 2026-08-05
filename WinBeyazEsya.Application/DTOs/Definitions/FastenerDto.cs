using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class FastenerDto : BaseDto
{
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public FastenerType? FastenerType { get; set; }
    public MaterialType? MaterialType { get; set; }
    
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
    public long? QualityStandardId { get; set; }
}

