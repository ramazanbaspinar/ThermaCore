using System.Collections.Generic;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Services.Management;

public interface IUserService
{
    UserDto GetById(long id);
    IEnumerable<UserListDto> GetAll();
    long Insert(UserDto dto);
    void Update(UserDto dto);
    void Delete(long id);

    UserDto? UserLogin(string code, string password);
}
