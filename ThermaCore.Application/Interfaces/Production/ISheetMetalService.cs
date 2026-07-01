using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface ISheetMetalService
{
    SheetMetalDto GetById(long id);
    IEnumerable<SheetMetalListDto> GetAll();
    long Insert(SheetMetalDto dto);
    void Update(SheetMetalDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
