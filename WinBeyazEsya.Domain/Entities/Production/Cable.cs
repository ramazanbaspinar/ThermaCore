using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Production;

using WinBeyazEsya.Domain.Enums;

public class Cable : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public CableType? CableType { get; set; }
    public string? CrossSection { get; set; }
    public decimal? LengthMm { get; set; }
    public int? MaxTemperature { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}

