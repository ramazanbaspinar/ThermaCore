using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;

namespace ThermaCore.Domain.Entities.Production;

public class SparkPlug : FullAuditableEntity
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;

    public decimal? LengthMm { get; set; }
    public string? ConnectionType { get; set; }
    public string? SparkTipType { get; set; }
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}
