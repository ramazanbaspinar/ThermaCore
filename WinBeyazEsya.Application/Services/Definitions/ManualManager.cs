using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

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

