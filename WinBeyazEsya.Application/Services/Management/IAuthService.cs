using System.Collections.Generic;
using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Services.Management;

public interface IAuthService
{
    Task<List<TenantDatabaseDto>> GetAllowedTenantsByUsernameAsync(string username);
    Task<LoginResultDto> LoginAsync(string username, string password, long tenantId);
    Task<bool> CheckTerminalAccessAsync(string username, string hardwareFingerprint, long tenantId);
    Task<List<BranchDto>> GetAllowedBranchesAsync(long userId, long tenantId);
    bool HasPermission(WinBeyazEsya.Domain.Enums.ModuleType moduleType, WinBeyazEsya.Domain.Enums.PermissionType permissionType);
    Task<string> GetDefaultTenantConnectionStringAsync(long? preferredTenantId = null);
}

