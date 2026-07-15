using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production;

public class GasPipeDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? Diameter { get; set; }
    public decimal? LengthMm { get; set; }
    public int? BranchCount { get; set; }
    public PipeType? PipeType { get; set; }
    public GasType? GasType { get; set; }
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
}
