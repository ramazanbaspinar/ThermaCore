using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum TrayType
{
    [Description("Standart")]
    Standard = 1,
    
    [Description("Derin")]
    Deep = 2,
    
    [Description("Sığ")]
    Shallow = 3,
    
    [Description("Cam")]
    Glass = 4
}
