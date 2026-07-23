using System;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class UnitConversionListDto : BaseDto
{
    public long EntityId { get; set; }
    public long UnitId { get; set; }
    public string UnitName { get; set; } = string.Empty;
    public decimal Multiplier { get; set; }
    public decimal Divisor { get; set; }
    public bool IsMainUnit { get; set; }
}
