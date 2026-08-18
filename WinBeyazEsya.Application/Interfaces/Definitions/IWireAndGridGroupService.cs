using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IWireAndGridGroupService : IBaseService
{
    WireAndGridGroupDto GetById(long id);
    IEnumerable<WireAndGridGroupListDto> GetAll();
    long Insert(WireAndGridGroupDto dto);
    void Update(WireAndGridGroupDto dto);
    void Delete(long id);
}

