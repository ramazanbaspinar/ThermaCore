using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum DateFormat
{
    [Description("Tanımsız (Yok)")]
    None = 0,
    [Description("yyyy")]
    yyyy = 1,
    [Description("yy")]
    yy = 2,
    [Description("yyMM")]
    yyMM = 3,
    [Description("yyyyMM")]
    yyyyMM = 4,
    [Description("yyMMdd")]
    yyMMdd = 5,
    [Description("yyyyMMdd")]
    yyyyMMdd = 6,
    [Description("MMdd")]
    MMdd = 7,
    [Description("MMyy")]
    MMyy = 8
}

