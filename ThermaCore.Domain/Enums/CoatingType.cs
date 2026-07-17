using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum CoatingType
{
    [Description("Emaye")]
    Enamel = 1,
    
    [Description("Alüminyum")]
    Aluminum = 2,
    
    [Description("Teflon")]
    NonStick = 3,
    
    [Description("Paslanmaz")]
    Stainless = 4
}
