using System.Collections.Generic;
using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Interfaces.System;

public interface IExchangeRateService
{
    Task SyncTcmbRatesAsync();
    List<ExchangeRateDto> GetAllRates();
    ExchangeRateDto GetRateById(long id);
    void UpdateEffectiveRates(long id, decimal effectiveBuying, decimal effectiveSelling);
}
