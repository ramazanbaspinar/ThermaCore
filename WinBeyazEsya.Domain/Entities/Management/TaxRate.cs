using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Management;

public class TaxRate : FullAuditableEntity
{
    public TaxType TaxType { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public string? Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}

