using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class MetalSheetGroupDto : BaseDto
{
    public string Name { get; set; } = null!;

    public long BaseUnitId { get; set; }
    public string BaseUnitName { get; set; } = string.Empty;

    public long? SpecialCodeId { get; set; }

    public string? SurfaceType { get; set; }
    public string? QualityCode { get; set; }

    public decimal Width { get; set; }
    public decimal Length { get; set; }
    public decimal Thickness { get; set; }

    public WinBeyazEsya.Domain.Enums.SurfaceCoatingType SurfaceCoatingType { get; set; }

    public decimal Density { get; set; }
    public decimal Weight { get; set; }

    public string? Description { get; set; }
}
