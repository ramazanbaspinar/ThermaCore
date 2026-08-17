using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Integration;

namespace WinBeyazEsya.Application.Interfaces.Integration;

public interface IIntegrationService
{
    Task<IntegrationResult> SyncCountriesAsync(string ip, string db, string user, string pass, int entType, string customQuery);
    Task<IntegrationResult> SyncCitiesAsync(string ip, string db, string user, string pass, int entType, string customQuery);
    Task<IntegrationResult> SyncTownsAsync(string ip, string db, string user, string pass, int entType, string customQuery);
    Task<IntegrationResult> SyncCurrentAccountsAsync(string ip, string db, string user, string pass, string firmaNo, int entType, string customQuery);
}
