using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production;

public class HotplateDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public HotplateType? HotplateType { get; set; }
    public decimal? DiameterMm { get; set; }
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public string? Description { get; set; }

    // Relations
    public long? SpecialCodeId { get; set; }
}

public class HotplateListDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public string? HotplateTypeName { get; set; }
    public decimal? DiameterMm { get; set; }
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public string? Description { get; set; }
    public string? SpecialCodeName { get; set; }
}
