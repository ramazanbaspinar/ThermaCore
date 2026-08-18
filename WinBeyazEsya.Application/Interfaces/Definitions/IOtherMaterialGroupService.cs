using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IOtherMaterialGroupService : IBaseService
{
    OtherMaterialGroupDto GetById(long id);
    IEnumerable<OtherMaterialGroupListDto> GetAll();
    long Insert(OtherMaterialGroupDto dto);
    void Update(OtherMaterialGroupDto dto);
    void Delete(long id);
}

