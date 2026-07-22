using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum LabelMaterialType
{
    [Description("Metalize-Gümüş")]
    Metalized = 1,
    
    [Description("Polipropilen-Yırtılmaz")]
    PP = 2,
    
    [Description("Kuşe Kağıt")]
    Paper = 3,
    
    [Description("Termal")]
    Thermal = 4
}
