using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class GeneralExpenseDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}

