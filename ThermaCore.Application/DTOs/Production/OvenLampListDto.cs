using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class OvenLampListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? LampTypeName { get; set; }
    public string? SocketType { get; set; }
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public int? MaxTemperature { get; set; }
    public string? Description { get; set; }
    public string? SpecialCodeName { get; set; }
}
