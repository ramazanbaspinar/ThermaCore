using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Services.Production;

public class SparkPlugManager : BaseManager<SparkPlugListDto, SparkPlugDto, SparkPlug>, ISparkPlugService
{
    public SparkPlugManager(
        IMapper mapper,
        IRepository<SparkPlug> repository,
        IUnitOfWork unitOfWork,
        IValidator<SparkPlugDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<SparkPlugListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<SparkPlugListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }



    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }
}
