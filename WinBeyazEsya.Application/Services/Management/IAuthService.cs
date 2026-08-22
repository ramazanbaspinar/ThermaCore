using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Services.Management;

public interface IAuthService
{
    Task<List<TenantDatabaseDto>> GetAllowedTenantsByUsernameAsync(string username);
    Task<LoginResultDto> LoginAsync(string username, string password, long tenantId);
    Task<bool> CheckTerminalAccessAsync(string username, string hardwareFingerprint, long tenantId);
    Task<List<BranchDto>> GetAllowedBranchesAsync(long userId, long tenantId);
    bool HasPermission(WinBeyazEsya.Domain.Enums.ModuleType moduleType, WinBeyazEsya.Domain.Enums.PermissionType permissionType);
    bool HasSpecialPermission(WinBeyazEsya.Domain.Enums.ModuleType moduleType, string specialPermissionKey);
    global::System.Collections.Generic.List<WinBeyazEsya.Domain.Entities.Management.User> GetUsersWithSpecialPermission(WinBeyazEsya.Domain.Enums.ModuleType moduleType, string specialPermissionKey);
    global::System.Threading.Tasks.Task<string> GetDefaultTenantConnectionStringAsync(long? preferredTenantId = null);
}
