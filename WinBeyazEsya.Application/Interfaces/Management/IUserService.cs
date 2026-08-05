using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Interfaces.Management;

public interface IUserService
{
    UserDto GetById(long id);
    IEnumerable<UserDto> GetAll();
    IEnumerable<UserListDto> GetActiveUsers();
    long Insert(UserDto dto);
    void Update(UserDto dto);
    void Delete(long id);
    UserDto UserLogin(string username, string password);
}

