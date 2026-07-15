using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Definitions;

public class HingeListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public HingeType? HingeType { get; set; }
    public MountingDirection? MountingDirection { get; set; }
    public decimal? LoadCapacityKg { get; set; }
    public string? Description { get; set; }
}
