using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class OvenGlassDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public decimal? ThicknessMm { get; set; }
    public decimal? WidthMm { get; set; }
    public decimal? HeightMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string? SpecialCode { get; set; }

    public long? GlassTypeId { get; set; }
    public string? GlassTypeName { get; set; }

    public long? ColorFeatureId { get; set; }
    public string? ColorFeatureName { get; set; }
}

