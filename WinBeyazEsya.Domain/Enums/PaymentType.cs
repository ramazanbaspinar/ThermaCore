using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum PaymentType
{
    [Description("Peşin")]
    Pesin = 1,
    
    [Description("Vadeli")]
    Vadeli = 2,
    
    [Description("Kredi Kartı")]
    KrediKarti = 3,
    
    [Description("Çek")]
    Cek = 4,
    
    [Description("Senet")]
    Senet = 5
}
