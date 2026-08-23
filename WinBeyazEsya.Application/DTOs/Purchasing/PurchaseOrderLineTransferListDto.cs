using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Purchasing;

public class PurchaseOrderLineTransferListDto : BaseDto
{
    public long PurchaseOrderId { get; set; }
    public long PurchaseOrderLineId { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Code { get; set; }
    public string? DocumentNo { get; set; }

    public long MaterialId { get; set; }
    public string? MaterialName { get; set; }

    public decimal Quantity { get; set; }
    public decimal ReceivedQuantity { get; set; }
    public decimal PendingQuantity { get; set; }

    public long UnitId { get; set; }
    public string? UnitName { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal TaxRate { get; set; }

    public long? WarehouseId { get; set; }
    public string? WarehouseName { get; set; }

    // Kurumsal ERP Standartlarına Göre Eklenen 3 Yeni Kolon
    public string? CurrencyCode { get; set; }
    public decimal PendingLineTotal { get; set; }
    public DateTime? DeliveryDate { get; set; }
}
