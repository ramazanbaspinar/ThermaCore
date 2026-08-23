using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Purchasing;

public class PurchaseReceiptDto : BaseDto
{
    public string Code { get; set; } = string.Empty;
    public string? DocumentNo { get; set; }
    public DateTime ReceiptDate { get; set; }
    public long SupplierId { get; set; }
    public long? WarehouseId { get; set; }
    public string? CurrencyCode { get; set; }
    public decimal ExchangeRate { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal GrandTotal { get; set; }
    public string? Description { get; set; }

    public ICollection<PurchaseReceiptLineDto> Lines { get; set; } = new List<PurchaseReceiptLineDto>();
}
