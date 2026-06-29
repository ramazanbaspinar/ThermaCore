using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class SystemParameterDto : BaseDto
{
    public string? CompanyName { get; set; }
    public string? TaxOffice { get; set; }
    public string? TaxNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? LocalCurrency { get; set; }
    public byte[]? Logo { get; set; }
    
    public long? DefaultPurchaseKdvId { get; set; }
    public long? DefaultSalesKdvId { get; set; }
    public long? DefaultOtvId { get; set; }

    public decimal DefaultWastageRate { get; set; }
}
