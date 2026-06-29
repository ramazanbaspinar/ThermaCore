using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production;

public class QualityStandardDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public MaterialGroup MaterialGroup { get; set; }
    public string Description { get; set; } = string.Empty;
}
