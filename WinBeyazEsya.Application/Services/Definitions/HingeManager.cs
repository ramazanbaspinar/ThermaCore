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

public class HingeManager : BaseManager<HingeListDto, HingeDto, Hinge>, IHingeService
{
    public HingeManager(
        IMapper mapper, 
        IRepository<Hinge> repository, 
        IUnitOfWork unitOfWork, 
        IValidator<HingeDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<HingeListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<HingeListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }

}

