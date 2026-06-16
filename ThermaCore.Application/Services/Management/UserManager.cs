using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Services.Management;

public class UserManager : BaseMasterManager<UserListDto, UserDto, User>, IUserService
{
    private readonly ICryptoService _cryptoService;

    public UserManager(
        IMapper mapper, 
        IMasterRepository<User> repository, 
        IMasterUnitOfWork unitOfWork, 
        IValidator<UserDto> validator,
        ICryptoService cryptoService) 
        : base(mapper, repository, unitOfWork, validator)
    {
        _cryptoService = cryptoService;
    }

    public UserDto? UserLogin(string code, string password)
    {
        // Find active user with matching Code
        var user = _repository.Find(k => k.Code == code && k.IsActive).FirstOrDefault();
        
        if (user == null)
            return null;

        var hashedPassword = _cryptoService.EncryptMd5(password);
        
        if (user.Password == hashedPassword)
        {
            return _mapper.Map<UserDto>(user);
        }

        return null;
    }
}
