using System.ComponentModel.DataAnnotations.Schema;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Definitions;

public class Hinge : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public HingeType? HingeType { get; set; }
    public MountingDirection? MountingDirection { get; set; }
    public decimal? LoadCapacityKg { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
}
