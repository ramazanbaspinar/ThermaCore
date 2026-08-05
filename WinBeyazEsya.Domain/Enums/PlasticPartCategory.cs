using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums
{
    public enum PlasticPartCategory
    {
        [Description("Ayak")]
        Foot = 1,
        [Description("Bağlantı-Destek")]
        Bracket = 2,
        [Description("Ara Mesafe")]
        Spacer = 3,
        [Description("Kapak-Çerçeve")]
        Cover = 4
    }
}

