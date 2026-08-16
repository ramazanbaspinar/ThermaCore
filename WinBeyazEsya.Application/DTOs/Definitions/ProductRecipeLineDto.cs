using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ProductRecipeLineDto : BaseHareketDto
{
    public long ProductRecipeId { get; set; }
    public long MaterialId { get; set; }
    public MaterialType MaterialType { get; set; }
    
    // UI için ekstra alanlar
    public string? MaterialGroupName { get; set; }
    
    public string? MaterialName { get; set; }
    
    public decimal Quantity { get; set; }
    public long UnitId { get; set; }
    public string? UnitName { get; set; }
    
    // Reçete gridindeki diğer UI readonly sütunları
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
