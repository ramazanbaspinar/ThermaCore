using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Purchasing;

public class PurchaseReceiptListDto : BaseDto
{
    public string Code { get; set; } = string.Empty;
    public string? DocumentNo { get; set; }
    public DateTime ReceiptDate { get; set; }
    public long SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? SupplierCode { get; set; }
    public decimal GrandTotal { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public string CreatedUserName { get; set; } = string.Empty;
}
