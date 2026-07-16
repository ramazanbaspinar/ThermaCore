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

public class GasketManager : BaseManager<GasketListDto, GasketDto, Gasket>, IGasketService
{
    public GasketManager(
        IMapper mapper, 
        IRepository<Gasket> repository, 
        IUnitOfWork unitOfWork) 
        : base(mapper, repository, unitOfWork, new ThermaCore.Application.Validations.Definitions.GasketValidator())
    {
    }

    public override IEnumerable<GasketListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<GasketListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }
}
