using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Production;

public class GasValve : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public GasType? GasType { get; set; }
    public bool HasSafetyValve { get; set; }
    public int? OutletAngle { get; set; }
    public string? ShaftType { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}

