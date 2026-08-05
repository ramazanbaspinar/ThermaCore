using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class HeatingElementDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public decimal? TubeDiameterMm { get; set; }
    public decimal? LengthMm { get; set; }
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
}

