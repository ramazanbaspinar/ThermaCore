using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Production;

public class OvenLamp : FullAuditableEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public LampType? LampType { get; set; }
    public string? SocketType { get; set; }
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public int? MaxTemperature { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // Relations
    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }
}
