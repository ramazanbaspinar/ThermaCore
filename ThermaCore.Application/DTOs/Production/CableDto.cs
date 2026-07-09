using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class CableDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public ThermaCore.Domain.Enums.CableType? CableType { get; set; }
    public string? CrossSection { get; set; }
    public decimal? LengthMm { get; set; }
    public int? MaxTemperature { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string? SpecialCode { get; set; }
}
