using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Common;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Services.Common;

public class ItemBarcodeManager : BaseManager<ItemBarcodeListDto, ItemBarcodeDto, ItemBarcode>, IItemBarcodeService
{
    private readonly ISystemParameterService _systemParameterService;

    public ItemBarcodeManager(
        IMapper mapper,
        IRepository<ItemBarcode> repository,
        IUnitOfWork unitOfWork,
        IValidator<ItemBarcodeDto> validator,
        ISystemParameterService systemParameterService) 
        : base(mapper, repository, unitOfWork, validator)
    {
        _systemParameterService = systemParameterService;
    }

    public override IEnumerable<ItemBarcodeListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<ItemBarcodeListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public List<ItemBarcodeListDto> GetBarcodes(long recordId, ModuleType moduleType)
    {
        var barcodes = _repository.Find(x => x.RecordId == recordId && x.ModuleType == moduleType).ToList();
        return _mapper.Map<List<ItemBarcodeListDto>>(barcodes);
    }

    public string GenerateInternalBarcode(string currentRecordCode)
    {
        string prefix = "SYS";
        try
        {
            var param = _systemParameterService.GetSystemParameterAsync().GetAwaiter().GetResult();
            if (param != null && !string.IsNullOrEmpty(param.CompanyBarcodePrefix))
            {
                prefix = param.CompanyBarcodePrefix;
            }
        }
        catch 
        { 
            // Fallback to "SYS" if service fails
        }
        
        return $"{prefix}-{currentRecordCode}";
    }

    public void BulkInsert(List<ItemBarcodeDto> items)
    {
        if (items == null || !items.Any()) return;

        var entities = new List<ItemBarcode>();
        foreach (var dto in items)
        {
            if (_validator != null)
                _validator.ValidateAndThrow(dto);

            if (dto.Id <= 0)
                dto.Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId();

            entities.Add(_mapper.Map<ItemBarcode>(dto));
        }

        foreach (var entity in entities)
        {
            _repository.Add(entity);
        }
        
        _unitOfWork.SaveChanges();
    }

    public void BulkUpdate(List<ItemBarcodeDto> items)
    {
        if (items == null || !items.Any()) return;

        foreach (var dto in items)
        {
            if (_validator != null)
                _validator.ValidateAndThrow(dto);

            var existingEntity = _repository.GetById(dto.Id);
            if (existingEntity != null)
            {
                _mapper.Map(dto, existingEntity);
                _repository.Update(existingEntity);
            }
        }
        
        _unitOfWork.SaveChanges();
    }

    public void BulkDelete(List<long> ids)
    {
        if (ids == null || !ids.Any()) return;

        foreach (var id in ids)
        {
            var entity = _repository.GetById(id);
            if (entity != null)
            {
                _repository.Remove(entity);
            }
        }
        
        _unitOfWork.SaveChanges();
    }
}

