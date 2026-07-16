using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class GasketListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public string? MaterialTypeName { get; set; }
    public int? HeatResistance { get; set; }
    public decimal? LengthMm { get; set; }
    public string? Description { get; set; }

    public string? SpecialCodeName { get; set; }
}
