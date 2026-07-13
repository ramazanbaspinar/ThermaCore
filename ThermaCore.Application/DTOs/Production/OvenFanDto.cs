using System;
using ThermaCore.Domain.Enums;

using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Production;

public class OvenFanDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public FanType? FanType { get; set; }
    public string? Material { get; set; }
    public decimal? DiameterMm { get; set; }
    public int? BladeCount { get; set; }
    public decimal? ShaftHoleMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
}
