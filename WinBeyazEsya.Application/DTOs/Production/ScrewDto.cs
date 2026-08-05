using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class ScrewDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? Diameter { get; set; }
    public decimal? LengthMm { get; set; }
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
}

