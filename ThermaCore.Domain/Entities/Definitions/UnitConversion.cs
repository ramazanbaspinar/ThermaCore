using System;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Definitions;

public class UnitConversion : FullAuditableEntity
{
    public long EntityId { get; set; }
    public long UnitId { get; set; }
    public decimal Multiplier { get; set; }
    public decimal Divisor { get; set; }
    public bool IsMainUnit { get; set; }
    public virtual Unit Unit { get; set; }
}
