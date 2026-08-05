using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum LockType
{
    [Description("Kanca Tipi")]
    Hook = 1,

    [Description("Makaralı")]
    Roller = 2,

    [Description("Elektronik")]
    Electronic = 3,

    [Description("Çocuk Kilidi")]
    ChildLock = 4
}

