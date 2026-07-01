using System;
using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Management;

public class SystemParameter : FullAuditableEntity
{
    [MaxLength(100)]
    public string? CompanyName { get; set; }

    [MaxLength(100)]
    public string? TaxOffice { get; set; }

    [MaxLength(50)]
    public string? TaxNumber { get; set; }

    [MaxLength(50)]
    public string? PhoneNumber { get; set; }

    [MaxLength(100)]
    public string? Email { get; set; }

    [MaxLength(500)]
    public string? Address { get; set; }

    [MaxLength(10)]
    public string? LocalCurrency { get; set; }

    public byte[]? Logo { get; set; }

    public long? DefaultPurchaseKdvId { get; set; }
    public long? DefaultSalesKdvId { get; set; }
    public long? DefaultOtvId { get; set; }

    public decimal DefaultWastageRate { get; set; }
    
    [MaxLength(20)]
    public string? CompanyBarcodePrefix { get; set; }
}
