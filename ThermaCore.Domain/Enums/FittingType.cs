using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum FittingType
{
    [Description("Düz")]
    Straight = 1,

    [Description("Dirsek-L")]
    Elbow = 2,

    [Description("T-Tipi")]
    Tee = 3
}
