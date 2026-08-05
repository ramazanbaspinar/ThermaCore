using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Services.Production;

public class OvenMotorManager : BaseManager<OvenMotorListDto, OvenMotorDto, OvenMotor>, IOvenMotorService
{
    public OvenMotorManager(
        IMapper mapper,
        IRepository<OvenMotor> repository,
        IUnitOfWork unitOfWork,
        IValidator<OvenMotorDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<OvenMotorListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<OvenMotorListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public IEnumerable<OvenMotorListDto> GetAllList()
    {
        return GetAll();
    }

    public IEnumerable<OvenMotorListDto> GetActiveList()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<OvenMotorListDto>(_repository.Find(x => x.IsActive), _mapper.ConfigurationProvider).ToList();
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }

    public override long Insert(OvenMotorDto dto)
    {
        if (!IsCodeUnique(dto.Id, dto.Code))
            throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Code", "Bu kod zaten kullanılıyor.") });

        return base.Insert(dto);
    }

    public override void Update(OvenMotorDto dto)
    {
        if (!IsCodeUnique(dto.Id, dto.Code))
            throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Code", "Bu kod zaten kullanılıyor.") });

        base.Update(dto);
    }
}

