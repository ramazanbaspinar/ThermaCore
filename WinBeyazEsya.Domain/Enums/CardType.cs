using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum CardType
{
    [Description("Alıcı(Müşteri)")]
    Musteri = 1,

    [Description("Satıcı(Tedarikçi)")]
    Tedarikci = 2,

    [Description("Hem Müşteri Hem Tedarikçi")]
    MusteriVeTedarikci = 3
}
