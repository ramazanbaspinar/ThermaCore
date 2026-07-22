using System;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class UnitConversionListDto : BaseDto
{
    public Guid EntityId { get; set; }
    public Guid UnitId { get; set; }
    public string UnitName { get; set; } = string.Empty;
    public decimal Multiplier { get; set; }
    public decimal Divisor { get; set; }
    public bool IsMainUnit { get; set; }
}
