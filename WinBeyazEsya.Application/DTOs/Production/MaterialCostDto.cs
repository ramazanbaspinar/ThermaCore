using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Production;

public class MaterialCostDto : BaseDto
{
    public ModuleType MaterialType { get; set; }
    public long MaterialId { get; set; }
    public decimal Cost { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public long BranchId { get; set; }
}

