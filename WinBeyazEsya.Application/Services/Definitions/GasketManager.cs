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

public class GasketManager : BaseManager<GasketListDto, GasketDto, Gasket>, IGasketService
{
    public GasketManager(
        IMapper mapper, 
        IRepository<Gasket> repository, 
        IUnitOfWork unitOfWork) 
        : base(mapper, repository, unitOfWork, new WinBeyazEsya.Application.Validations.Definitions.GasketValidator())
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

