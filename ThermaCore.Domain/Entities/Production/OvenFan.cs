using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Production;

public class OvenFan : FullAuditableEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public FanType? FanType { get; set; }
    public string? Material { get; set; }
    public decimal? DiameterMm { get; set; }
    public int? BladeCount { get; set; }
    public decimal? ShaftHoleMm { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // Relations
    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }
}
