using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface ISheetMetalTypeService
{
    SheetMetalTypeDto GetById(long id);
    IEnumerable<SheetMetalTypeListDto> GetAll();
    long Insert(SheetMetalTypeDto dto);
    void Update(SheetMetalTypeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
