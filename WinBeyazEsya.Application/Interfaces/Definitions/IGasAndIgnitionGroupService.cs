using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IGasAndIgnitionGroupService
{
    GasAndIgnitionGroupDto GetById(long id);
    IEnumerable<GasAndIgnitionGroupListDto> GetAll();
    long Insert(GasAndIgnitionGroupDto dto);
    void Update(GasAndIgnitionGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(string code, long id = 0);
}
