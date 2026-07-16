using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum InsulationType
{
    [Description("Taş Yünü")]
    RockWool = 1,
    
    [Description("Cam Yünü")]
    GlassWool = 2,
    
    [Description("Seramik Elyaf")]
    CeramicFiber = 3,
    
    [Description("Poliüretan")]
    Polyurethane = 4,

    [Description("Diğer")]
    Other = 99
}
