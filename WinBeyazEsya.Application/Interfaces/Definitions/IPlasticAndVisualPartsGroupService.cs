using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IPlasticAndVisualPartsGroupService : IBaseService
{
    PlasticAndVisualPartsGroupDto GetById(long id);
    IEnumerable<PlasticAndVisualPartsGroupListDto> GetAll();
    long Insert(PlasticAndVisualPartsGroupDto dto);
    void Update(PlasticAndVisualPartsGroupDto dto);
    void Delete(long id);
}

