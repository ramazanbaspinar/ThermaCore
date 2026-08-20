using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Purchasing;

public class PurchaseOrderLine : FullAuditableEntity
{
    public long PurchaseOrderId { get; set; }

    public long MaterialId { get; set; }

    public decimal Quantity { get; set; }

    public long UnitId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TaxRate { get; set; }

    public decimal LineTotal { get; set; }

    public decimal ReceivedQuantity { get; set; } = 0;

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
