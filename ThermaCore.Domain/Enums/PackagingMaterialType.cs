using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum PackagingMaterialType
{
    [Description("Karton")]
    Cardboard = 1,
    
    [Description("Strafor")]
    EPS = 2,
    
    [Description("Polietilen Naylon")]
    PE = 3,
    
    [Description("Ahşap")]
    Wood = 4
}
