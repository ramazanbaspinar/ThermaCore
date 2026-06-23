using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Services.System;

public class TenantDatabaseCrudManager : BaseMasterManager<TenantDatabaseDto, TenantDatabaseDto, TenantDatabase>, ITenantDatabaseCrudService
{
    public TenantDatabaseCrudManager(
        IMapper mapper, 
        IMasterRepository<TenantDatabase> repository, 
        IMasterUnitOfWork unitOfWork, 
        IValidator<TenantDatabaseDto> validator) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public IEnumerable<TenantDatabaseDto> GetActiveTenants()
    {
        var entities = _repository.Find(x => !x.IsDeleted && x.IsActive).ToList();
        return _mapper.Map<IEnumerable<TenantDatabaseDto>>(entities);
    }
}
