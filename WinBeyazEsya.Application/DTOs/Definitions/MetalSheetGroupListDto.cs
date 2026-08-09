using System;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class MetalSheetGroupListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnitName { get; set; } = string.Empty;
    public string? SurfaceType { get; set; }
    public string? QualityCode { get; set; }
    public decimal Width { get; set; }
    public decimal Length { get; set; }
    public decimal Thickness { get; set; }
    public string? SurfaceCoatingType { get; set; }
    public string? Description { get; set; }
}
