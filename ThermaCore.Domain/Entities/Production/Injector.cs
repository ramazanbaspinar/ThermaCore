using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Production;

public class Injector : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public GasType? GasType { get; set; }
    public string? TargetBurner { get; set; }
    public decimal? HoleDiameterMm { get; set; }
    public string? ThreadSize { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}
