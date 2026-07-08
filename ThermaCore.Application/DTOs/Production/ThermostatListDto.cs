using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class ThermostatListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? MinTemperature { get; set; }
    public int? MaxTemperature { get; set; }
    public int? CurrentAmper { get; set; }
    public decimal? CapillaryLengthMm { get; set; }
    public string? Description { get; set; }
    public string? SpecialCodeName { get; set; }
}
