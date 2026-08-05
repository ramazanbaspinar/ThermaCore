using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

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

