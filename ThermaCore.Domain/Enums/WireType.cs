using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum WireType
{
    [Description("Ham Demir")]
    Iron = 1,

    [Description("Krom")]
    Chrome = 2,

    [Description("Paslanmaz Çelik")]
    StainlessSteel = 3
}
