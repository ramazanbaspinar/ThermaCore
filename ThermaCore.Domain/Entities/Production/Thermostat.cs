using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;

namespace ThermaCore.Domain.Entities.Production;

public class Thermostat : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? MinTemperature { get; set; }
    public int? MaxTemperature { get; set; }
    public int? CurrentAmper { get; set; }
    public int? CapillaryLengthMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}
