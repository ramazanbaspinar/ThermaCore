using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production;

public class ValveListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public ValveType? ValveType { get; set; }
    public GasType? GasType { get; set; }
    public decimal? MaxPressureMbar { get; set; }
    public string? ConnectionSize { get; set; }
    public string? TemperatureRange { get; set; }
    public string? Description { get; set; }

    public string? SpecialCodeCode { get; set; }
    public string? SpecialCodeName { get; set; }
}
