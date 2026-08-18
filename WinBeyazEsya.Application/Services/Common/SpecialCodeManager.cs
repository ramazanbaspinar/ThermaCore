using FluentValidation;
using WinBeyazEsya.Application.DTOs.Common;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Services.Common;

public class SpecialCodeManager : ISpecialCodeService
{
    private readonly IRepository<SpecialCode> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<SpecialCodeDto> _validator;

    public SpecialCodeManager(IRepository<SpecialCode> repository, IUnitOfWork unitOfWork, IValidator<SpecialCodeDto> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public List<SpecialCodeDto> GetCodes(SpecialCodeType codeType, string entityType)
    {
        var entities = _repository.Find(x => x.CodeType == codeType && x.EntityType == entityType).ToList();
        return entities.Select(x => new SpecialCodeDto
        {
            Id = x.Id,
            CodeType = x.CodeType,
            EntityType = x.EntityType,
            Code = x.Code,
            Name = x.Name,
            Description = x.Description
        }).ToList();
    }

    public SpecialCodeDto GetById(long id)
    {
        var entity = _repository.GetById(id);
        if (entity == null) return null;

        return new SpecialCodeDto
        {
            Id = entity.Id,
            CodeType = entity.CodeType,
            EntityType = entity.EntityType,
            Code = entity.Code,
            Name = entity.Name,
            Description = entity.Description
        };
    }

    public long Insert(SpecialCodeDto dto)
    {
        _validator.ValidateAndThrow(dto);

        if (!IsCodeUnique(dto.Id, dto.CodeType, dto.EntityType, dto.Code))
        {
            throw new ValidationException(new List<FluentValidation.Results.ValidationFailure>
            {
                new FluentValidation.Results.ValidationFailure("Code", "Girilen kod zaten kullanılıyor.")
            });
        }

        var entity = new SpecialCode
        {
            Id = dto.Id,
            CodeType = dto.CodeType,
            EntityType = dto.EntityType,
            Code = dto.Code,
            Name = dto.Name,
            Description = dto.Description
        };

        _repository.Add(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public void Update(SpecialCodeDto dto)
    {
        _validator.ValidateAndThrow(dto);

        if (!IsCodeUnique(dto.Id, dto.CodeType, dto.EntityType, dto.Code))
        {
            throw new ValidationException(new List<FluentValidation.Results.ValidationFailure>
            {
                new FluentValidation.Results.ValidationFailure("Code", "Girilen kod zaten kullanılıyor.")
            });
        }

        var entity = _repository.GetById(dto.Id);
        if (entity != null)
        {
            entity.Code = dto.Code;
            entity.Name = dto.Name;
            entity.Description = dto.Description;

            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }
    }

    public void Delete(long id)
    {
        var entity = _repository.GetById(id);
        if (entity != null)
        {
            _repository.Remove(entity);
            _unitOfWork.SaveChanges();
        }
    }

    public bool IsCodeUnique(long id, SpecialCodeType codeType, string entityType, string code)
    {
        return !_repository.Find(x => x.Id != id && x.CodeType == codeType && x.EntityType == entityType && x.Code == code).Any();
    }
}

