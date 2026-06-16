using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Services.Management;

public class UserRoleManager : BaseMasterManager<UserRoleListDto, UserRoleDto, UserRole>, IUserRoleService
{
    public UserRoleManager(
        IMapper mapper, 
        IMasterRepository<UserRole> repository, 
        IMasterUnitOfWork unitOfWork, 
        IValidator<UserRoleDto> validator) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }
}
