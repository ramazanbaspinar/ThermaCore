using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Production;

public class InjectorDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public GasType? GasType { get; set; }
    public string? TargetBurner { get; set; }
    public decimal? HoleDiameterMm { get; set; }
    public string? ThreadSize { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string? SpecialCodeCode { get; set; }
    public string? SpecialCodeName { get; set; }
}

