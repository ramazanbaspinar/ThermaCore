using System;
using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Management;

public class ExchangeRate : FullAuditableEntity
{
    public DateTime RateDate { get; set; }

    [Required]
    [MaxLength(10)]
    public string CurrencyCode { get; set; } = string.Empty;

    public decimal EffectiveBuyingRate { get; set; }
    public decimal EffectiveSellingRate { get; set; }
    
    public decimal TcmbBuyingRate { get; set; }
    public decimal TcmbSellingRate { get; set; }
}
