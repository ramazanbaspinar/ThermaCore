using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Definitions;

public class InsulationDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;

    public InsulationType? InsulationType { get; set; }

    public decimal? ThicknessMm { get; set; }

    public int? Density { get; set; }

    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
}
