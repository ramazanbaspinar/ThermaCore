using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class ProductRecipeLine : FullAuditableEntity
{
    public long ProductRecipeId { get; set; }
    public virtual ProductRecipe ProductRecipe { get; set; } = null!;

    public long MaterialId { get; set; }
    public MaterialType MaterialType { get; set; }

    public decimal Quantity { get; set; }

    public long UnitId { get; set; }
    public virtual Unit Unit { get; set; } = null!;

    public decimal WasteRate { get; set; }

    public decimal WeightKg { get; set; }
    public string? SurfaceCoatingType { get; set; }
    public decimal CoatingAmount { get; set; }
    public decimal UnitPrice { get; set; }
    public string? CurrencyCode { get; set; }
    public decimal TotalMaterialCost { get; set; }
    public long? CoatingMaterialId { get; set; }
    public decimal ManualCoatingCost { get; set; }
    public long? SupplierId { get; set; }
    public string? Description { get; set; }
}
