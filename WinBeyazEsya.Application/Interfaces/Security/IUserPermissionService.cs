using WinBeyazEsya.Application.DTOs.Security;

namespace WinBeyazEsya.Application.Interfaces.Security;

public interface IUserPermissionService
{
    IEnumerable<UserPermissionDto> GetUserPermissions(long userId);
    void SaveUserPermissions(long userId, List<UserPermissionDto> permissions);
    void DeleteUserPermissions(long userId);
}

