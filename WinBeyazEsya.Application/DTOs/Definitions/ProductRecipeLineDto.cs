using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ProductRecipeLineDto : BaseHareketDto
{
    public long ProductRecipeId { get; set; }
    public long MaterialId { get; set; }
    public MaterialType MaterialType { get; set; }
    
    // UI iÃ§in ekstra alanlar
    public string? MaterialGroupName { get; set; }
    
    public string? MaterialName { get; set; }
    
    public decimal Quantity { get; set; }
    public long UnitId { get; set; }
    public string? UnitName { get; set; }
    
    public decimal WasteRate { get; set; }

    // ReÃ§ete gridindeki diÄŸer UI readonly sÃ¼tunlarÄ±
    public decimal Weight { get; set; }
    public string? SurfaceCoatingType { get; set; }
    public decimal CoatingAmount { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalMaterialCost { get; set; }
    public long? SupplierId { get; set; }
    public string? Description { get; set; }
}
