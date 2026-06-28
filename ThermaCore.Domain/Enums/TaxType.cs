using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum TaxType
{
    [Description("KDV")]
    Kdv = 1,

    [Description("ÖTV")]
    Otv = 2
}
