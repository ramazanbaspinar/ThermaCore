using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Purchasing;

public class PurchaseReceiptLineDto : BaseDto
{
    public long PurchaseReceiptId { get; set; }
    public long MaterialId { get; set; }
    public decimal Quantity { get; set; }
    public long UnitId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TaxRate { get; set; }
    public decimal LineTotal { get; set; }
    public long? WarehouseId { get; set; }
    public long? PurchaseOrderLineId { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    
}
