using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Management;

public class TaxRateListDto : BaseDto
{
    public TaxType TaxType { get; set; }
    public decimal Rate { get; set; }
    public string? Description { get; set; } = string.Empty;
}

