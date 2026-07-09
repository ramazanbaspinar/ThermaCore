using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class ColorFeatureListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
