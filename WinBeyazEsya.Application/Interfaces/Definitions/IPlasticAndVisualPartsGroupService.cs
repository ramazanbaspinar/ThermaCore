using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IPlasticAndVisualPartsGroupService
{
    PlasticAndVisualPartsGroupDto GetById(long id);
    IEnumerable<PlasticAndVisualPartsGroupListDto> GetAll();
    long Insert(PlasticAndVisualPartsGroupDto dto);
    void Update(PlasticAndVisualPartsGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(string code, long id = 0);
}
