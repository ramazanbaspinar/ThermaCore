using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Purchasing;

public class PurchaseOrderLineDto : BaseDto
{
    public long PurchaseOrderId { get; set; }
    public long MaterialId { get; set; }
    public decimal Quantity { get; set; }
    public long UnitId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TaxRate { get; set; }
    public decimal LineTotal { get; set; }
    public decimal ReceivedQuantity { get; set; }
    public long? WarehouseId { get; set; }

    // UI için Unbound/Display kolonu
    public string? CurrencyCode { get; set; }

    public decimal RemainingQuantity
    {
        get { return Quantity - ReceivedQuantity; }
    }

    public decimal ConversionFactor { get; set; } = 1m;

    public decimal BaseReceivedQuantity => ReceivedQuantity * ConversionFactor;

    public decimal BaseRemainingQuantity => (Quantity - ReceivedQuantity) * ConversionFactor;
}
