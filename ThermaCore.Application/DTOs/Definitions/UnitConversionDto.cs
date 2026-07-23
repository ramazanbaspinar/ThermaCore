using System;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class UnitConversionDto : BaseDto
{
    public long EntityId { get; set; }
    public long UnitId { get; set; }
    public decimal Multiplier { get; set; }
    public decimal Divisor { get; set; }
    public bool IsMainUnit { get; set; }
}
