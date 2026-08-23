using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum OrderStatus
{
    [Description("Taslak")]
    Draft = 1,

    [Description("Onay Bekliyor")]
    WaitingApproval = 2,

    [Description("Onaylandı")]
    Approved = 3,

    [Description("Kısmi Kabul")]
    PartialReceived = 4,

    [Description("Tamamlandı")]
    Completed = 5,

    [Description("İptal")]
    Canceled = 6
}
