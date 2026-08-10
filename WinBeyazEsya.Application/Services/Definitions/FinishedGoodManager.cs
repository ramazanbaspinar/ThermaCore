using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Services.Definitions;

public class FinishedGoodManager : BaseManager<FinishedGoodListDto, FinishedGoodDto, FinishedGood>, IFinishedGoodService
{
    private readonly IRepository<ItemBarcode> _barcodeRepository;

    public FinishedGoodManager(
        IMapper mapper, 
        IRepository<FinishedGood> repository, 
        IRepository<ItemBarcode> barcodeRepository,
        IUnitOfWork unitOfWork,
        IValidator<FinishedGoodDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
        _barcodeRepository = barcodeRepository;
    }

    public override IEnumerable<FinishedGoodListDto> GetAll()
    {
        var entities = _repository.GetAll().ToList();
        var dtos = _mapper.Map<List<FinishedGoodListDto>>(entities);

        if (dtos.Any())
        {
            var recordIds = dtos.Select(d => d.Id).ToList();
            
            var primaryBarcodes = _barcodeRepository.Find(b => 
                b.ModuleType == ModuleType.FinishedGood && 
                b.IsPrimary && 
                recordIds.Contains(b.RecordId))
                .ToList();

            foreach (var dto in dtos)
            {
                var barcode = primaryBarcodes.FirstOrDefault(b => b.RecordId == dto.Id);
                if (barcode != null)
                {
                    dto.PrimaryBarcode = barcode.BarcodeValue;
                }
            }
        }

        return dtos;
    }
}
