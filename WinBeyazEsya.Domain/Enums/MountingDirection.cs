using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum MountingDirection
{
    [Description("Sağ")]
    Right = 1,

    [Description("Sol")]
    Left = 2,

    [Description("Çift Yönlü")]
    Bidirectional = 3,

    [Description("Üst")]
    Top = 4,

    [Description("Alt")]
    Bottom = 5,

    [Description("Diğer")]
    Other = 99
}

