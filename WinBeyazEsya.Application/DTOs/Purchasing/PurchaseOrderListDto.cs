using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Purchasing;

public class PurchaseOrderListDto : BaseDto
{
    public string? DocumentNo { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }

    public long SupplierId { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string SupplierCode { get; set; } = string.Empty;



    public WinBeyazEsya.Domain.Enums.OrderStatus Status { get; set; }
    public string StatusName { get; set; } = string.Empty;

    public decimal GrandTotal { get; set; }
    public string? Description { get; set; }

    public string CreatedFullName { get; set; } = string.Empty;
}
