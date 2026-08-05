using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Production;

public class MaterialCostListDto : BaseDto
{
    public ModuleType MaterialType { get; set; }
    public long MaterialId { get; set; }
    public string MaterialName { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}

