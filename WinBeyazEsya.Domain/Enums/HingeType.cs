using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum HingeType
{
    [Description("Standart")]
    Standard = 1,
    
    [Description("Frenli")]
    SoftClose = 2,
    
    [Description("Gizli")]
    Concealed = 3,
    
    [Description("Ağır Yük")]
    HeavyDuty = 4,
    
    [Description("Diğer")]
    Other = 99
}

