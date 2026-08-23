using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Purchasing;

public class PurchaseReceipt : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? DocumentNo { get; set; }

    public DateTime ReceiptDate { get; set; }

    public long SupplierId { get; set; }

    public long? WarehouseId { get; set; }

    [MaxLength(5)]
    public string? CurrencyCode { get; set; }

    public decimal ExchangeRate { get; set; } = 1;

    public decimal SubTotal { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal GrandTotal { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public virtual ICollection<PurchaseReceiptLine> Lines { get; set; } = new List<PurchaseReceiptLine>();
}
