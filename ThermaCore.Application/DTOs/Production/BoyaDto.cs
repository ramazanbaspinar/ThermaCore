using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class BoyaDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? ColorCode { get; set; }
    public int? HeatResistance { get; set; }
    public int? DryingTimeMinutes { get; set; }
    public int? ShelfLifeMonths { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
}
