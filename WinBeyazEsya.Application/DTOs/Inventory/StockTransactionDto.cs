using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Inventory;

public class StockTransactionDto : BaseDto
{
    public long MaterialId { get; set; }
    public long WarehouseId { get; set; }
    public DocumentType DocumentType { get; set; }
    public long DocumentId { get; set; }
    public MovementType MovementType { get; set; }
    public decimal Quantity { get; set; }
    public DateTime TransactionDate { get; set; }
}
