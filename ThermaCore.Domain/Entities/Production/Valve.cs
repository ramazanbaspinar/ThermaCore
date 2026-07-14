using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Production;

public class Valve : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public ValveType? ValveType { get; set; }
    public GasType? GasType { get; set; }
    public decimal? MaxPressureMbar { get; set; }
    public string? ConnectionSize { get; set; }
    public string? TemperatureRange { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}
