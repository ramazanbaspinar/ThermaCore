using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Services.Production;

public class ThermocoupleManager : IThermocoupleService
{
    private readonly IRepository<Thermocouple> _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<ThermocoupleDto> _validator;
    private readonly IUnitOfWork _uow;

    public ThermocoupleManager(
        IRepository<Thermocouple> repository,
        IMapper mapper,
        IValidator<ThermocoupleDto> validator,
        IUnitOfWork uow)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
        _uow = uow;
    }

    public ThermocoupleDto GetById(long id)
    {
        var entity = _repository.GetById(id);
        return _mapper.Map<ThermocoupleDto>(entity);
    }

    public List<ThermocoupleListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<ThermocoupleListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public ThermocoupleDto Add(ThermocoupleDto dto)
    {
        var validationResult = _validator.Validate(dto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = _mapper.Map<Thermocouple>(dto);
        _repository.Add(entity);
        _uow.SaveChanges();

        return _mapper.Map<ThermocoupleDto>(entity);
    }

    public ThermocoupleDto Update(ThermocoupleDto dto)
    {
        var validationResult = _validator.Validate(dto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingEntity = _repository.GetById(dto.Id);
        if (existingEntity == null)
            throw new Exception("Kayıt bulunamadı!");

        _mapper.Map(dto, existingEntity);
        _repository.Update(existingEntity);
        _uow.SaveChanges();

        return _mapper.Map<ThermocoupleDto>(existingEntity);
    }

    public void Delete(long id)
    {
        var entity = _repository.GetById(id);
        if (entity != null)
        {
            _repository.Remove(entity);
            _uow.SaveChanges();
        }
    }


}
