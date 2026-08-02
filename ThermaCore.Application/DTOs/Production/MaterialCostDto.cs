using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production;

public class MaterialCostDto : BaseDto
{
    public ModuleType MaterialType { get; set; }
    public long MaterialId { get; set; }
    public decimal Cost { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}
