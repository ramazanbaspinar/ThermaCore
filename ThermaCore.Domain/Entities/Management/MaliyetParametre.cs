using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Management;

public class MaliyetParametre : FullAuditableEntity
{
    public decimal MaturityDifferenceRate { get; set; }
    public decimal WastageRate { get; set; }
    public decimal AverageProductionValue { get; set; }
}
