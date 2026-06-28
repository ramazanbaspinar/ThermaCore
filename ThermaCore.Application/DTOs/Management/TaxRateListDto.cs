using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Management;

public class TaxRateListDto
{
    public long Id { get; set; }
    public TaxType TaxType { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public string? Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
