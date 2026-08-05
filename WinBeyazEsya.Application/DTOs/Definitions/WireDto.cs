using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class WireDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public WireType? WireType { get; set; }
    public decimal? DiameterMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
}

