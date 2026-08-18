using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IGasAndIgnitionGroupService : IBaseService
{
    GasAndIgnitionGroupDto GetById(long id);
    IEnumerable<GasAndIgnitionGroupListDto> GetAll();
    long Insert(GasAndIgnitionGroupDto dto);
    void Update(GasAndIgnitionGroupDto dto);
    void Delete(long id);
}


