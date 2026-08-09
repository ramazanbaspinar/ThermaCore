using System;

using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Management;

public class ExchangeRateDto : BaseDto
{

    public DateTime RateDate { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;

    public decimal EffectiveBuyingRate { get; set; }
    public decimal EffectiveSellingRate { get; set; }
    
    public decimal TcmbBuyingRate { get; set; }
    public decimal TcmbSellingRate { get; set; }
}

