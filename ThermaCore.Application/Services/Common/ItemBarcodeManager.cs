using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Common;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Services.Common;

public class ItemBarcodeManager : BaseManager<ItemBarcodeListDto, ItemBarcodeDto, ItemBarcode>, IItemBarcodeService
{
    public ItemBarcodeManager(
        IMapper mapper,
        IRepository<ItemBarcode> repository,
        IUnitOfWork unitOfWork,
        IValidator<ItemBarcodeDto> validator) 
        : base(mapper, repository, unitOfWork, validator)
    {
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
}
