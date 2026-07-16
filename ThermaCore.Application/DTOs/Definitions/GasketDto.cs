using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Definitions;

public class GasketDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public GasketMaterialType? MaterialType { get; set; }
    public int? HeatResistance { get; set; }
    public decimal? LengthMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
}
