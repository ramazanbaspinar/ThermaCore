using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Common;

public class SpecialCodeDto : BaseDto
{
    public SpecialCodeType CodeType { get; set; }
    public string EntityType { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
