using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Base;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Application.Services.Base;

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
        if (_validator != null)
        {
            _validator.ValidateAndThrow(dto);
        }

        var entity = _mapper.Map<TEntity>(dto);
        _repository.Add(entity);
        _unitOfWork.SaveChanges();
        return entity.Id;
    }

    public virtual void Update(TDto dto)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(dto);
        }

        var entity = _mapper.Map<TEntity>(dto);
        _repository.Update(entity);
        _unitOfWork.SaveChanges();
    }

    public virtual void Delete(long id)
    {
        var entity = _repository.GetById(id);
        if (entity != null)
        {
            _repository.Remove(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
