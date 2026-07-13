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

public class BurnerManager : BaseManager<BurnerListDto, BurnerDto, Burner>, IBurnerService
{
    public BurnerManager(
        IMapper mapper,
        IRepository<Burner> repository,
        IUnitOfWork unitOfWork,
        IValidator<BurnerDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<BurnerListDto> GetAll()
    {
        var query = _repository.GetAll().OrderBy(x => x.Code);
        return _mapper.Map<IEnumerable<BurnerListDto>>(query);
    }

    public bool IsCodeUnique(long id, string code)
    {
        return !_repository.Find(x => x.Code == code && x.Id != id).Any();
    }
}
