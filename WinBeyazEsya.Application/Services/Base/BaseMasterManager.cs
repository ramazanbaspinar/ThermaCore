using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Application.Services.Base;

public abstract class BaseMasterManager<TListDto, TDto, TEntity>
    where TListDto : class
    where TDto : BaseDto
    where TEntity : Entity
{
    protected readonly IMapper _mapper;
    protected readonly IMasterRepository<TEntity> _repository;
    protected readonly IMasterUnitOfWork _unitOfWork;
    protected readonly IValidator<TDto>? _validator;

    public BaseMasterManager(IMapper mapper, IMasterRepository<TEntity> repository, IMasterUnitOfWork unitOfWork, IValidator<TDto>? validator = null)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public virtual TDto GetById(long id)
    {
        var entity = _repository.GetById(id);
        return _mapper.Map<TDto>(entity);
    }

    public virtual IEnumerable<TListDto> GetAll()
    {
        var entities = _repository.GetAll().ToList();
        return _mapper.Map<IEnumerable<TListDto>>(entities);
    }

    public virtual long Insert(TDto dto)
    {
        try
        {
            if (_validator != null)
            {
                _validator.ValidateAndThrow(dto);
            }

            var entity = _mapper.Map<TEntity>(dto);
            _repository.Add(entity);
            _unitOfWork.SaveChanges();
            return entity.Id;
        }
        catch (ValidationException) { throw; }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "BaseMasterManager.Insert işlemi sırasında hata oluştu. Dto türü: {DtoType}", typeof(TDto).Name);
            throw;
        }
    }

    public virtual void Update(TDto dto)
    {
        try
        {
            if (_validator != null)
            {
                _validator.ValidateAndThrow(dto);
            }

            var existingEntity = _repository.GetById(dto.Id);
            if (existingEntity != null)
            {
                _mapper.Map(dto, existingEntity);
                _unitOfWork.SaveChanges();
            }
        }
        catch (ValidationException) { throw; }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "BaseMasterManager.Update işlemi sırasında hata oluştu. Dto türü: {DtoType}", typeof(TDto).Name);
            throw;
        }
    }

    public virtual void Delete(long id)
    {
        try
        {
            var entity = _repository.GetById(id);
            if (entity != null)
            {
                if (_repository.IsInUse(entity))
                {
                    throw new InvalidOperationException("Güvenlik Kısıtlaması: Bu kayıt sistemde başka işlemler tarafından kullanılmaktadır ve silinemez! Listelerde görünmesini istemiyorsanız lütfen kaydı 'Pasif' duruma getirin.");
                }

                _repository.Remove(entity);
                _unitOfWork.SaveChanges();
            }
        }
        catch (InvalidOperationException) { throw; }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "BaseMasterManager.Delete işlemi sırasında hata oluştu. Entity türü: {EntityType}, Id: {Id}", typeof(TEntity).Name, id);
            throw;
        }
    }
}

