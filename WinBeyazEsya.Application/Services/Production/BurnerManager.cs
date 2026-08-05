using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Services.Production;

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

