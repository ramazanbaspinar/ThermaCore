using ThermaCore.Domain.Enums;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class TaxRateListDto : BaseDto
{
    public TaxType TaxType { get; set; }
    public decimal Rate { get; set; }
    public string? Description { get; set; } = string.Empty;
}
