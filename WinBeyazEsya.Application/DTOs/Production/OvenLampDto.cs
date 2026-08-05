using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Production;

public class OvenLampDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public LampType? LampType { get; set; }
    public string? SocketType { get; set; }
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public int? MaxTemperature { get; set; }
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
}

