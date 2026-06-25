using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class UnitDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
