using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class HeatingElementListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public decimal? TubeDiameterMm { get; set; }
    public decimal? LengthMm { get; set; }
    public string? Description { get; set; }
}
