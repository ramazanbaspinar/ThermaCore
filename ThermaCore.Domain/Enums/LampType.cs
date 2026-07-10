using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum LampType
{
    [Description("Standart")]
    Standard = 1,
    
    [Description("Halojen")]
    Halogen = 2,
    
    [Description("LED")]
    Led = 3,
    
    [Description("Diğer")]
    Other = 99
}
