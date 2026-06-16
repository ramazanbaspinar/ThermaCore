using System.Collections.Generic;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Services.Management;

public interface IUserRoleService
{
    UserRoleDto GetById(long id);
    IEnumerable<UserRoleListDto> GetAll();
    long Insert(UserRoleDto dto);
    void Update(UserRoleDto dto);
    void Delete(long id);
}
