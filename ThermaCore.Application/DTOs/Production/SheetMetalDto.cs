using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class SheetMetalDto : BaseDto
{
    public string Name { get; set; } = string.Empty;

    public long QualityStandardId { get; set; }
    public long SurfaceTypeId { get; set; }
    public long UnitId { get; set; }
    public decimal Thickness { get; set; }
    public decimal Density { get; set; }
    public byte[]? Image { get; set; }
    public string? Description { get; set; }
}
