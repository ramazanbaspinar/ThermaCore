using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Security;

namespace WinBeyazEsya.Application.Interfaces.Security;

public interface IRoleService
{
    RoleDto GetById(long id);
    IEnumerable<RoleDto> GetAll();
    IEnumerable<RoleDto> GetActiveRoles();
    
    IEnumerable<RolePermissionDto> GetRolePermissions(long roleId);
    IEnumerable<RolePermissionDto> GetEmptyPermissions();
    
    long SaveRoleWithPermissions(RoleDto role, List<RolePermissionDto> permissions);
    void Delete(long id);
}

