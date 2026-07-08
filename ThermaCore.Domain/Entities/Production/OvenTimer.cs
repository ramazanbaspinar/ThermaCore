using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;

namespace ThermaCore.Domain.Entities.Production;

public class OvenTimer : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;

    public int? MaxDurationMinutes { get; set; }
    public string? TimerType { get; set; }
    public int? CurrentAmper { get; set; }
    public int? Voltage { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}
