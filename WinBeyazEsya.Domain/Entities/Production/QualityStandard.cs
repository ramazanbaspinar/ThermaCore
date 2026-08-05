using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Production;

public class QualityStandard : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public MaterialGroup MaterialGroup { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

