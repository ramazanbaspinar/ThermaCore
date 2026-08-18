using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Interfaces.System;

public interface IExchangeRateService
{
    Task<bool> SyncTcmbRatesAsync();
    List<ExchangeRateDto> GetAllRates();
    ExchangeRateDto GetRateById(long id);
    void UpdateEffectiveRates(long id, decimal effectiveBuying, decimal effectiveSelling);
}

