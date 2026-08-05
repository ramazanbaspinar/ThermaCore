using System;
using WinBeyazEsya.Domain.Enums;

using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class OvenFanListDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public FanType? FanType { get; set; }
    public string? Material { get; set; }
    public decimal? DiameterMm { get; set; }
    public int? BladeCount { get; set; }
    public decimal? ShaftHoleMm { get; set; }
    public string? Description { get; set; }
    public string? SpecialCodeName { get; set; }
}

