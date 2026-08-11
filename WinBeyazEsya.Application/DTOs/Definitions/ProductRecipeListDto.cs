using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ProductRecipeListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string FinishedGoodName { get; set; } = string.Empty;
    public string? Description { get; set; }
}
