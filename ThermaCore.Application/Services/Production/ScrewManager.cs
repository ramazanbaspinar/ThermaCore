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

public class ScrewManager : BaseManager<ScrewListDto, ScrewDto, Screw>, IScrewService
{
    public ScrewManager(
        IMapper mapper,
        IRepository<Screw> repository,
        IUnitOfWork unitOfWork,
        IValidator<ScrewDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<ScrewListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<ScrewListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }

    public override long Insert(ScrewDto dto)
    {
        if (!IsCodeUnique(dto.Id, dto.Code))
            throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Code", "Bu kod zaten kullanılıyor.") });

        return base.Insert(dto);
    }

    public override void Update(ScrewDto dto)
    {
        if (!IsCodeUnique(dto.Id, dto.Code))
            throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Code", "Bu kod zaten kullanılıyor.") });

        base.Update(dto);
    }
}
