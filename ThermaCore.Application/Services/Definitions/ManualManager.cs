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

public class ManualManager : BaseManager<ManualListDto, ManualDto, Manual>, IManualService
{
    public ManualManager(
        IMapper mapper,
        IRepository<Manual> repository,
        IUnitOfWork unitOfWork,
        IValidator<ManualDto> validator) : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<ManualListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<ManualListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }
}
