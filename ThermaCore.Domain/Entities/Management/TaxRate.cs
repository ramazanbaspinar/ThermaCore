using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Management;

public class TaxRate : FullAuditableEntity
{
    public TaxType TaxType { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public string? Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
