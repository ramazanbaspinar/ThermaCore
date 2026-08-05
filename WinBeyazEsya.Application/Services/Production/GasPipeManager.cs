using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Services.Production;

public class GasPipeManager : BaseManager<GasPipeListDto, GasPipeDto, GasPipe>, IGasPipeService
{
    public GasPipeManager(
        IMapper mapper,
        IRepository<GasPipe> repository,
        IUnitOfWork unitOfWork,
        IValidator<GasPipeDto>? validator = null) : base(mapper, repository, unitOfWork, validator)
    {
    }

    public bool IsCodeUnique(long id, string code)
    {
        return !_repository.Find(x => x.Id != id && x.Code == code).Any();
    }
}

