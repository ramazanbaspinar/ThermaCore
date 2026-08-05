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

public class KnobManager : BaseManager<KnobListDto, KnobDto, Knob>, IKnobService
{
    public KnobManager(
        IMapper mapper,
        IRepository<Knob> repository,
        IUnitOfWork unitOfWork,
        IValidator<KnobDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<KnobListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<KnobListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }

    public override long Insert(KnobDto dto)
    {
        if (!IsCodeUnique(dto.Id, dto.Code))
            throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Code", "Bu kod zaten kullanılıyor.") });

        return base.Insert(dto);
    }

    public override void Update(KnobDto dto)
    {
        if (!IsCodeUnique(dto.Id, dto.Code))
            throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Code", "Bu kod zaten kullanılıyor.") });

        base.Update(dto);
    }
}

