using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Application.Services.Base;

public abstract class BaseManager<TListDto, TDto, TEntity> 
    where TListDto : class
    where TDto : BaseDto 
    where TEntity : Entity
{
    protected readonly IMapper _mapper;
    protected readonly IRepository<TEntity> _repository;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IValidator<TDto>? _validator;

    public BaseManager(IMapper mapper, IRepository<TEntity> repository, IUnitOfWork unitOfWork, IValidator<TDto>? validator = null)
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

    protected virtual void CheckBusinessRules(TDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Code) || dto.Code == "Yeni Kod" || dto.Code == "< Otomatik Üretilecek >")
            return;

        var entityType = typeof(TEntity);
        var codeProp = entityType.GetProperty("Code");
        
        if (codeProp != null)
        {
            var parameter = Expression.Parameter(entityType, "x");
            
            var codeProperty = Expression.Property(parameter, "Code");
            var codeValue = Expression.Constant(dto.Code);
            var codeEquals = Expression.Equal(codeProperty, codeValue);

            var idProperty = Expression.Property(parameter, "Id");
            var idValue = Expression.Constant(dto.Id);
            var idNotEquals = Expression.NotEqual(idProperty, idValue);

            var combined = Expression.AndAlso(codeEquals, idNotEquals);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(combined, parameter);

            if (_repository.Find(lambda).Any())
            {
                throw new ValidationException(new[] { 
                    new FluentValidation.Results.ValidationFailure("Code", "Girdiğiniz benzersiz kod (Code) sistemde zaten kullanılmaktadır. Lütfen farklı bir kod giriniz.") 
                });
            }
        }
    }

    public virtual long Insert(TDto dto)
    {
        try
        {
            if (_validator != null)
            {
                _validator.ValidateAndThrow(dto);
            }

            CheckBusinessRules(dto);

            var entity = _mapper.Map<TEntity>(dto);
            _repository.Add(entity);
            _unitOfWork.SaveChanges();
            return entity.Id;
        }
        catch (ValidationException) { throw; }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "BaseManager.Insert işlemi sırasında hata oluştu. Dto türü: {DtoType}", typeof(TDto).Name);
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

            CheckBusinessRules(dto);

            var existingEntity = _repository.GetById(dto.Id);
            if (existingEntity != null)
            {
                _mapper.Map(dto, existingEntity);
                _repository.Update(existingEntity);
                _unitOfWork.SaveChanges();
            }
        }
        catch (ValidationException) { throw; }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "BaseManager.Update işlemi sırasında hata oluştu. Dto türü: {DtoType}", typeof(TDto).Name);
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
            Serilog.Log.Error(ex, "BaseManager.Delete işlemi sırasında hata oluştu. Entity türü: {EntityType}, Id: {Id}", typeof(TEntity).Name, id);
            throw;
        }
    }
}

