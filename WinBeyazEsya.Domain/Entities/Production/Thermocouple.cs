using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Production;

public class Thermocouple : FullAuditableEntity
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public decimal? LengthMm { get; set; }
    public string? HeadType { get; set; }
    public string? TipType { get; set; }
    public string? Description { get; set; }
    
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}

