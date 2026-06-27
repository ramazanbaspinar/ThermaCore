using System.Collections.Generic;
using ThermaCore.Application.DTOs.Security;

namespace ThermaCore.Application.Interfaces.Security;

public interface IUserPermissionService
{
    IEnumerable<UserPermissionDto> GetUserPermissions(long userId);
    void SaveUserPermissions(long userId, List<UserPermissionDto> permissions);
    void DeleteUserPermissions(long userId);
}
