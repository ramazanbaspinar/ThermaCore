using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Purchasing;

public class PurchaseReceiptLine : FullAuditableEntity
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

    public virtual PurchaseReceipt PurchaseReceipt { get; set; } = null!;
    
    public virtual PurchaseOrderLine? PurchaseOrderLine { get; set; }
}
