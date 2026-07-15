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
