using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum CableType
{
    [Description("Fişli Kablo")]
    PlugCable = 1,
    
    [Description("Kablo Grubu")]
    CableGroup = 2,
    
    [Description("Diğer")]
    Other = 3
}
