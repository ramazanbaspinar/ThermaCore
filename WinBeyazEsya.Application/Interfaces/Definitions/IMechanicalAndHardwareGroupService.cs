using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IMechanicalAndHardwareGroupService
{
    MechanicalAndHardwareGroupDto GetById(long id);
    IEnumerable<MechanicalAndHardwareGroupListDto> GetAll();
    long Insert(MechanicalAndHardwareGroupDto dto);
    void Update(MechanicalAndHardwareGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(string code, long id = 0);
}
