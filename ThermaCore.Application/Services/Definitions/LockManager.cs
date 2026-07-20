using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Services.Definitions;

public class LockManager : BaseManager<LockListDto, LockDto, Lock>, ILockService
{
    public LockManager(
        IMapper mapper,
        IRepository<Lock> repository,
        IUnitOfWork unitOfWork,
        IValidator<LockDto> validator) : base(mapper, repository, unitOfWork, validator)
    {
    }
}
