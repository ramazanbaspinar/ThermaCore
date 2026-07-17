using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Services.Definitions;

public class FittingManager : BaseManager<FittingListDto, FittingDto, Fitting>, IFittingService
{
    public FittingManager(
        IMapper mapper,
        IRepository<Fitting> repository,
        IUnitOfWork unitOfWork,
        IValidator<FittingDto> validator) : base(mapper, repository, unitOfWork, validator)
    {
    }
}
