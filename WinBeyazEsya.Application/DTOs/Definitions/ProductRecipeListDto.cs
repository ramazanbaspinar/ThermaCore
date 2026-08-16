using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ProductRecipeListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string FinishedGoodName { get; set; } = string.Empty;
    public string RevisionNumber { get; set; } = "01";
    public System.DateTime Date { get; set; }
    public decimal TotalCost { get; set; }
    public decimal NetMaterialCost { get; set; }
    public string? Description { get; set; }
}
