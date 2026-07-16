using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Definitions;

public class Wire : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public WireType? WireType { get; set; }
    public decimal? DiameterMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}
