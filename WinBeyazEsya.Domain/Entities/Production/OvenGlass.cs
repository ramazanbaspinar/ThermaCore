using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Production;

public class OvenGlass : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public decimal? ThicknessMm { get; set; }
    public decimal? WidthMm { get; set; }
    public decimal? HeightMm { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }

    public long? GlassTypeId { get; set; }
    public virtual GlassType? GlassType { get; set; }

    public long? ColorFeatureId { get; set; }
    public virtual ColorFeature? ColorFeature { get; set; }
}

