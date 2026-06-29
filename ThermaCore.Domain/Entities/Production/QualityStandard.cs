using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Production;

public class QualityStandard : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public MaterialGroup MaterialGroup { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
