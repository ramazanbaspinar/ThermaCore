using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Management;

public class MaliyetParametreDto : BaseDto
{
    [Category("Finansal Parametreler")]
    [DisplayName("Vade Farkı Oranı")]
    [Description("Maliyet hesaplamalarında kullanılacak olan vade farkı oranını belirtir.")]
    public decimal MaturityDifferenceRate { get; set; }

    [Category("Üretim Parametreleri")]
    [DisplayName("Fire Oranı")]
    [Description("Üretim sırasındaki genel fire oranını temsil eder.")]
    public decimal WastageRate { get; set; }

    public bool UseMaturityDifference { get; set; }
    public bool UseWasteRate { get; set; }
    public int OvenAvgMonthlyProduction { get; set; }
    public int CookerAvgMonthlyProduction { get; set; }
    public int BuiltInAvgMonthlyProduction { get; set; }
    public int FreestandingAvgMonthlyProduction { get; set; }
    public int OtherAvgMonthlyProduction { get; set; }
    
    [Browsable(false)]
    public long BranchId { get; set; }
}

