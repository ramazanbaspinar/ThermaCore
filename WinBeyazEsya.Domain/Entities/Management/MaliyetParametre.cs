using System.ComponentModel.DataAnnotations.Schema;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

[Table("CostParameters")]
public class MaliyetParametre : FullAuditableEntity, IMustHaveBranch
{
    public decimal MaturityDifferenceRate { get; set; }
    public decimal WastageRate { get; set; }
    public bool UseMaturityDifference { get; set; }
    public bool UseWasteRate { get; set; }
    public int OvenAvgMonthlyProduction { get; set; }
    public int CookerAvgMonthlyProduction { get; set; }
    public int BuiltInAvgMonthlyProduction { get; set; }
    public int FreestandingAvgMonthlyProduction { get; set; }
    public int OtherAvgMonthlyProduction { get; set; }
    public long BranchId { get; set; }
}

