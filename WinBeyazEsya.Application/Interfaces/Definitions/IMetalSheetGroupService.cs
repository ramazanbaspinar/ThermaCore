using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IMetalSheetGroupService : IBaseService
{
    MetalSheetGroupDto GetById(long id);
    IEnumerable<MetalSheetGroupListDto> GetAll();
    long Insert(MetalSheetGroupDto dto);
    void Update(MetalSheetGroupDto dto);
    void Delete(long id);
}

