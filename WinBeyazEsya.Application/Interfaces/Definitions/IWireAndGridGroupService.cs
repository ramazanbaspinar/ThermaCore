using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IWireAndGridGroupService
{
    WireAndGridGroupDto GetById(long id);
    IEnumerable<WireAndGridGroupListDto> GetAll();
    long Insert(WireAndGridGroupDto dto);
    void Update(WireAndGridGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
