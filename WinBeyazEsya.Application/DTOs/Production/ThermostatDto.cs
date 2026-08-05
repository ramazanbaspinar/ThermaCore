using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class ThermostatDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? MinTemperature { get; set; }
    public int? MaxTemperature { get; set; }
    public int? CurrentAmper { get; set; }
    public decimal? CapillaryLengthMm { get; set; }
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
}

