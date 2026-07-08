using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class RotarySwitchDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? CurrentAmper { get; set; }
    public int? Voltage { get; set; }
    public string? Position { get; set; }
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
}
