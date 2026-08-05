using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

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

    [Category("Üretim Parametreleri")]
    [DisplayName("Ortalama Üretim Değeri")]
    [Description("Üretim birimlerinin ortalama üretim maliyet değeridir.")]
    public decimal AverageProductionValue { get; set; }
}
