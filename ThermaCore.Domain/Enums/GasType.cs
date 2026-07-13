using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum GasType
{
    [Description("LPG")]
    Lpg = 1,

    [Description("Doğalgaz")]
    NaturalGas = 2,
    
    [Description("Bilinmiyor/Diğer")]
    Other = 3
}
