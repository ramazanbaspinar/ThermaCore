using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum FanType
{
    [Description("Turbo Pervane")]
    TurboBlade = 1,

    [Description("Soğutma Pervanesi")]
    CoolingBlade = 2,

    [Description("Diğer")]
    Other = 3
}

