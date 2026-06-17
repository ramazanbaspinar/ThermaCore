using System.Collections.Generic;
using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Services.Management;

public interface IAuthService
{
    Task<List<TenantDatabaseDto>> GetAllowedTenantsByUsernameAsync(string username);
    Task<LoginResultDto> LoginAsync(string username, string password, long tenantId);
    Task<bool> CheckTerminalAccessAsync(string hardwareFingerprint, long tenantId);
}
