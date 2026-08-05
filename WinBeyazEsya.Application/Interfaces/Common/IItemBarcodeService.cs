using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Interfaces.Common;

public interface IItemBarcodeService
{
    ItemBarcodeDto GetById(long id);
    IEnumerable<ItemBarcodeListDto> GetAll();
    long Insert(ItemBarcodeDto dto);
    void Update(ItemBarcodeDto dto);
    void Delete(long id);
    List<ItemBarcodeListDto> GetBarcodes(long recordId, ModuleType moduleType);
}

