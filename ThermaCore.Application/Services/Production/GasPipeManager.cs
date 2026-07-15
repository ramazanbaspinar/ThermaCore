using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Services.Production;

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
