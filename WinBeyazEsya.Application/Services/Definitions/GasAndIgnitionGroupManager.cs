using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class GasAndIgnitionGroupManager : BaseManager<GasAndIgnitionGroupListDto, GasAndIgnitionGroupDto, GasAndIgnitionGroup>, IGasAndIgnitionGroupService
{
    public GasAndIgnitionGroupManager(
        IMapper mapper,
        IRepository<GasAndIgnitionGroup> repository,
        IUnitOfWork unitOfWork,
        IValidator<GasAndIgnitionGroupDto>? validator = null)
        : base(mapper, repository, unitOfWork, validator)
    {
    }
}

