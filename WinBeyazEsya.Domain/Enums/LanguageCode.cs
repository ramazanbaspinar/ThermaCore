using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum LanguageCode
{
    [Description("Türkçe")]
    TR = 1,
    [Description("İngilizce")]
    EN = 2,
    [Description("Almanca")]
    DE = 3,
    [Description("Fransızca")]
    FR = 4,
    [Description("Çoklu Dil")]
    Multi = 5
}

