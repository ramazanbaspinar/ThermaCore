using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum GasketMaterialType
{
    [Description("Silikon")]
    Silicone = 1,
    
    [Description("Cam Elyaf")]
    Fiberglass = 2,
    
    [Description("Çelik Tel Örgü")]
    WireMesh = 3,
    
    [Description("Kauçuk")]
    Rubber = 4,
    
    [Description("Diğer")]
    Other = 99
}

