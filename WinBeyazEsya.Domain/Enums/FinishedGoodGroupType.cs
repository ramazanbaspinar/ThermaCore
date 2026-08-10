using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum FinishedGoodGroupType
{
    [Description("Fırın")]
    Firin = 1,
    
    [Description("Ocak")]
    Ocak = 2,
    
    [Description("Ankastre")]
    Ankastre = 3,
    
    [Description("Davlumbaz")]
    Davlumbaz = 4,
    
    [Description("Diğer")]
    Diger = 5
}
