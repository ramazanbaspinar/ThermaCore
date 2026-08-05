using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Services.System;

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

