using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ProductRecipeDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public long FinishedGoodId { get; set; }

    public string? Description { get; set; }
    public string RevisionNumber { get; set; } = "01";
    
    public long BranchId { get; set; }

    public IList<ProductRecipeLineDto> Lines { get; set; } = new List<ProductRecipeLineDto>();
}
