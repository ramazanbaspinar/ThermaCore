using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IGasAndIgnitionGroupService : IBaseService
{
    GasAndIgnitionGroupDto GetById(long id);
    IEnumerable<GasAndIgnitionGroupListDto> GetAll();
    long Insert(GasAndIgnitionGroupDto dto);
    void Update(GasAndIgnitionGroupDto dto);
    void Delete(long id);
}


