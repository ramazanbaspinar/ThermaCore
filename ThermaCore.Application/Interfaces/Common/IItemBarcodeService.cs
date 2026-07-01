using System.Collections.Generic;
using ThermaCore.Application.DTOs.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Interfaces.Common;

public interface IItemBarcodeService
{
    ItemBarcodeDto GetById(long id);
    IEnumerable<ItemBarcodeListDto> GetAll();
    long Insert(ItemBarcodeDto dto);
    void Update(ItemBarcodeDto dto);
    void Delete(long id);
    List<ItemBarcodeListDto> GetBarcodes(long recordId, ModuleType moduleType);
}
