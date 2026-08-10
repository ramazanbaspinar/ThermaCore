using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class FinishedGoodDto : BaseDto
{
    public string Name { get; set; } = null!;
    
    public long? GroupId { get; set; }
    
    public long UnitId { get; set; }
    public string? UnitName { get; set; }

    public long? SpecialCodeId { get; set; }

    public decimal SalesPrice { get; set; }
    public decimal SalesVatRate { get; set; }

    public string? Description { get; set; }
    public byte[]? Picture { get; set; }
}
