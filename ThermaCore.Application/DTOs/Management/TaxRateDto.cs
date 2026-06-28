using ThermaCore.Domain.Enums;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class TaxRateDto : BaseDto
{
    public TaxType TaxType { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public string? Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
