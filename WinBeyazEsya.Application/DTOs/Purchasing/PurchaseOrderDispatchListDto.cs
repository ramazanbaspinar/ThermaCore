using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Purchasing;

public class PurchaseOrderDispatchListDto : BaseDto
{
    public long MaterialId { get; set; }
    public string MaterialName { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public long UnitId { get; set; }
    public string UnitName { get; set; } = string.Empty;
    public DateTime ReceiptDate { get; set; }
    public string ReceiptCode { get; set; } = string.Empty;
    public string DocumentNo { get; set; } = string.Empty;
}
