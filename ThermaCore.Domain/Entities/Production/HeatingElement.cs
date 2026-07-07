using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;

namespace ThermaCore.Domain.Entities.Production;

public class HeatingElement : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public decimal? TubeDiameterMm { get; set; }
    public decimal? LengthMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}
