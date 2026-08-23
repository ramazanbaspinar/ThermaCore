using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum DocumentType
{
    [Description("Bilinmeyen")]
    Unknown = 0,

    [Description("Satınalma İrsaliyesi")]
    PurchaseReceipt = 1,

    [Description("Üretim Fişi")]
    Production = 2,

    [Description("Sayım Fişi")]
    PhysicalInventory = 3,

    [Description("Satış İrsaliyesi")]
    SalesReceipt = 4
}
