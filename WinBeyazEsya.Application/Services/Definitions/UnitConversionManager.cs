using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class UnitConversionManager : IUnitConversionService
{
    private readonly IRepository<UnitConversion> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UnitConversionManager(IRepository<UnitConversion> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public UnitConversionDto GetById(long id)
    {
        var entity = _repository.GetById(id);
        return _mapper.Map<UnitConversionDto>(entity);
    }

    public IEnumerable<UnitConversionListDto> GetByEntityId(long entityId)
    {
        var entities = _repository.Find(x => x.EntityId == entityId).ToList();
        return _mapper.Map<IEnumerable<UnitConversionListDto>>(entities);
    }

    public void SaveChanges(long entityId, IEnumerable<UnitConversionDto> conversions)
    {
        var existingConversions = _repository.Find(x => x.EntityId == entityId).ToList();
        
        // Remove deleted conversions
        var toDeleteIds = existingConversions.Select(x => x.Id)
            .Except(conversions.Where(x => x.Id > 0).Select(x => x.Id))
            .ToList();
            
        foreach (var id in toDeleteIds)
        {
            var entityToDelete = existingConversions.First(e => e.Id == id);
            _repository.Remove(entityToDelete);
        }

        // Update or Add
        foreach (var dto in conversions)
        {
            if (dto.Id > 0)
            {
                var existing = existingConversions.FirstOrDefault(x => x.Id == dto.Id);
                if (existing != null)
                {
                    _mapper.Map(dto, existing);
                    existing.EntityId = entityId; // Safety assignment
                    _repository.Update(existing);
                }
            }
            else
            {
                var newEntity = _mapper.Map<UnitConversion>(dto);
                newEntity.Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId();
                newEntity.EntityId = entityId;
                _repository.Add(newEntity);
            }
        }
        
        _unitOfWork.SaveChanges();
    }
}


