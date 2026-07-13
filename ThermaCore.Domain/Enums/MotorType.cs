using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum MotorType
{
    [Description("Turbo")]
    Turbo = 1,
    
    [Description("Cooling")]
    Cooling = 2,
    
    [Description("Rotisserie")]
    Rotisserie = 3,
    
    [Description("Diğer")]
    Other = 99
}
