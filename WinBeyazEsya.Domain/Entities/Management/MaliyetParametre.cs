using WinBeyazEsya.Domain.Entities.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace WinBeyazEsya.Domain.Entities.Management;

[Table("CostParameters")]
public class MaliyetParametre : FullAuditableEntity, IMustHaveBranch
{
    public decimal MaturityDifferenceRate { get; set; }
    public decimal WastageRate { get; set; }
    public decimal AverageProductionValue { get; set; }
    public long BranchId { get; set; }
}

