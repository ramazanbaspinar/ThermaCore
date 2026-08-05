using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class SheetMetalListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;

    public string QualityStandardName { get; set; } = string.Empty;
    public string SurfaceTypeName { get; set; } = string.Empty;
    public string UnitName { get; set; } = string.Empty;
    public decimal Thickness { get; set; }
    public decimal Density { get; set; }
    public string? Description { get; set; }
}

