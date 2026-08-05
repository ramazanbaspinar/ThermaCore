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

public class SheetMetalManager : BaseManager<SheetMetalListDto, SheetMetalDto, SheetMetal>, ISheetMetalService
{
    public SheetMetalManager(
        IMapper mapper,
        IRepository<SheetMetal> repository,
        IUnitOfWork unitOfWork,
        IValidator<SheetMetalDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<SheetMetalListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<SheetMetalListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }
}

