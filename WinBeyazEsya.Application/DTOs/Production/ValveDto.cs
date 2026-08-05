using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Production;

public class ValveDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public ValveType? ValveType { get; set; }
    public GasType? GasType { get; set; }
    public decimal? MaxPressureMbar { get; set; }
    public string? ConnectionSize { get; set; }
    public string? TemperatureRange { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string? SpecialCodeCode { get; set; }
    public string? SpecialCodeName { get; set; }
}

