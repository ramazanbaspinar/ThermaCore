using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum HotplateType
{
    [Description("Standart")]
    Standard = 1,

    [Description("Hızlı (Rapid)")]
    Rapid = 2,

    [Description("Otomatik (Sensörlü)")]
    Automatic = 3,

    [Description("Kare / Dikdörtgen")]
    SquareOrRectangular = 4,

    [Description("Çok Bölgeli")]
    MultiZone = 5
}
