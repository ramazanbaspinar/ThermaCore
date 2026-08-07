using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IMetalSheetGroupService
{
    MetalSheetGroupDto GetById(long id);
    IEnumerable<MetalSheetGroupListDto> GetAll();
    long Insert(MetalSheetGroupDto dto);
    void Update(MetalSheetGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
