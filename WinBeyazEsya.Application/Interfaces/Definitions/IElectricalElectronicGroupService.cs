using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IElectricalElectronicGroupService : IBaseService
{
    ElectricalElectronicGroupDto GetById(long id);
    IEnumerable<ElectricalElectronicGroupListDto> GetAll();
    long Insert(ElectricalElectronicGroupDto dto);
    void Update(ElectricalElectronicGroupDto dto);
    void Delete(long id);
}

