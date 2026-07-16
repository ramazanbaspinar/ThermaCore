using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Services.Definitions;

public class InsulationManager : BaseManager<InsulationListDto, InsulationDto, Insulation>, IInsulationService
{
    public InsulationManager(
        IMapper mapper,
        IRepository<Insulation> repository,
        IUnitOfWork unitOfWork,
        IValidator<InsulationDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<InsulationListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<InsulationListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }
}
