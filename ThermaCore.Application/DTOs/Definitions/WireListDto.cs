using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Definitions;

public class WireListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public WireType? WireType { get; set; }
    public string WireTypeName { get; set; } = string.Empty;
    
    public decimal? DiameterMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string SpecialCodeName { get; set; } = string.Empty;
}
