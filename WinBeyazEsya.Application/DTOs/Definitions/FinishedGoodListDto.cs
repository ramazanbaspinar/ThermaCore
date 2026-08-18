using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class FinishedGoodListDto : BaseDto
{
    public string Name { get; set; } = null!;

    public WinBeyazEsya.Domain.Enums.FinishedGoodGroupType GroupType { get; set; }
    public string? GroupName { get; set; }
    public string? UnitName { get; set; }

    public decimal SalesPrice { get; set; }
    public decimal SalesVatRate { get; set; }

    public string? Description { get; set; }

    public string? PrimaryBarcode { get; set; }
}
