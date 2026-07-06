using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Common;

public class SpecialCode : FullAuditableEntity
{
    public SpecialCodeType CodeType { get; set; }
    public string EntityType { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
