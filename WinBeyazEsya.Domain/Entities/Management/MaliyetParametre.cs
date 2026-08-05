using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

public class MaliyetParametre : FullAuditableEntity
{
    public decimal MaturityDifferenceRate { get; set; }
    public decimal WastageRate { get; set; }
    public decimal AverageProductionValue { get; set; }
}

