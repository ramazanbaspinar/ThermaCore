using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Inventory;

public class StockTransaction : FullAuditableEntity
{
    public long MaterialId { get; set; }

    public long WarehouseId { get; set; }

    public DocumentType DocumentType { get; set; }

    public long DocumentId { get; set; }

    public MovementType MovementType { get; set; }

    public decimal Quantity { get; set; }

    public DateTime TransactionDate { get; set; }
}
