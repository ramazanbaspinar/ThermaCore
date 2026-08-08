using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IElectricalElectronicGroupService
{
    ElectricalElectronicGroupDto GetById(long id);
    IEnumerable<ElectricalElectronicGroupListDto> GetAll();
    long Insert(ElectricalElectronicGroupDto dto);
    void Update(ElectricalElectronicGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
