using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Production;

public class Knob : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? Color { get; set; }
    public string? ShaftType { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}

