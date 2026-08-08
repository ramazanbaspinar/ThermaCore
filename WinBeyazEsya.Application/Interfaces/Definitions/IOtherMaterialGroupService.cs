using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IOtherMaterialGroupService
{
    OtherMaterialGroupDto GetById(long id);
    IEnumerable<OtherMaterialGroupListDto> GetAll();
    long Insert(OtherMaterialGroupDto dto);
    void Update(OtherMaterialGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
