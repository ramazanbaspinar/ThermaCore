using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

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

