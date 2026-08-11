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

    public string GenerateInternalBarcode(ModuleType moduleType)
    {
        string prefix = "869"; // default
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
            // Fallback to "869" if service fails
        }
        
        int seqLength = 12 - prefix.Length;
        if(seqLength <= 0) seqLength = 5; // fallback
        
        var existingBarcodes = _repository.Find(x => x.ModuleType == moduleType && x.BarcodeValue.StartsWith(prefix)).ToList();
        
        long maxSeq = 0;
        foreach (var barcode in existingBarcodes)
        {
            if (barcode.BarcodeValue != null && barcode.BarcodeValue.Length == 13)
            {
                string seqPart = barcode.BarcodeValue.Substring(prefix.Length, seqLength);
                if (long.TryParse(seqPart, out long currentSeq))
                {
                    if (currentSeq > maxSeq) maxSeq = currentSeq;
                }
            }
        }
        
        maxSeq++;
        string newSeqStr = maxSeq.ToString().PadLeft(seqLength, '0');
        string coreBarcode = prefix + newSeqStr;
        
        // EAN-13 Checksum calculation
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            int digit = int.Parse(coreBarcode[i].ToString());
            sum += digit * (i % 2 == 0 ? 1 : 3);
        }
        int checksum = (10 - (sum % 10)) % 10;
        
        return coreBarcode + checksum.ToString();
    }

    private void ValidateUniqueness(List<ItemBarcodeDto> items)
    {
        var values = items.Where(x => !string.IsNullOrEmpty(x.BarcodeValue)).Select(x => x.BarcodeValue).ToList();
        var duplicatesInList = values.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
        if (duplicatesInList.Any())
        {
            throw new Exception($"Listede aynı barkod değeri birden fazla kez girilmiş: {string.Join(", ", duplicatesInList)}");
        }

        foreach (var item in items)
        {
            if (string.IsNullOrEmpty(item.BarcodeValue)) continue;
            var existing = _repository.Find(x => x.BarcodeValue == item.BarcodeValue && x.Id != item.Id).FirstOrDefault();
            if (existing != null)
            {
                throw new Exception($"Girdiğiniz barkod ({item.BarcodeValue}) sistemde başka bir kayıtta kullanılmaktadır!");
            }
        }
    }

    public void BulkInsert(List<ItemBarcodeDto> items)
    {
        if (items == null || !items.Any()) return;
        ValidateUniqueness(items);

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
        ValidateUniqueness(items);

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

