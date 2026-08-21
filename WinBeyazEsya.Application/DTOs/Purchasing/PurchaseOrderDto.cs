using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Purchasing;

public class PurchaseOrderDto : BaseDto
{
    public string? DocumentNo { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }

    public long SupplierId { get; set; }
    public long? WarehouseId { get; set; }
    public string? CurrencyCode { get; set; }

    public decimal ExchangeRate { get; set; }
    public OrderStatus Status { get; set; }

    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal GrandTotal { get; set; }

    public string? Description { get; set; }

    public List<PurchaseOrderLineDto> Lines { get; set; } = new();
}
