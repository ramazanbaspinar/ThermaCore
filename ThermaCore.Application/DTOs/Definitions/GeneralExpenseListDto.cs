using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class GeneralExpenseListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}
