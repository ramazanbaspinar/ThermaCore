using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum MovementType
{
    [Description("Giriş")]
    In = 1,

    [Description("Çıkış")]
    Out = 2
}
