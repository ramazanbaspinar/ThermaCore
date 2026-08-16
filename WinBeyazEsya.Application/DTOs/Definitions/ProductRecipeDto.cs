using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ProductRecipeDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public long FinishedGoodId { get; set; }

    public string? Description { get; set; }
    public System.DateTime Date { get; set; } = System.DateTime.Today;
    public string RevisionNumber { get; set; } = "01";
    
    public decimal TotalCost { get; set; }
    public decimal ExchangeRate { get; set; }
    public decimal NetMaterialCost { get; set; }
    
    public long BranchId { get; set; }

    public IList<ProductRecipeLineDto> Lines { get; set; } = new List<ProductRecipeLineDto>();
}
