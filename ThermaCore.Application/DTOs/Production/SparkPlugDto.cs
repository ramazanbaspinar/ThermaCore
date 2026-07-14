using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class SparkPlugDto : BaseDto
{
    // Id, Code, IsActive are inherited from BaseDto and MUST NOT be hidden!
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;

    public decimal? LengthMm { get; set; }
    public string? ConnectionType { get; set; }
    public string? SparkTipType { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string? SpecialCodeCode { get; set; }
}
