using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IMechanicalAndHardwareGroupService : IBaseService
{
    MechanicalAndHardwareGroupDto GetById(long id);
    IEnumerable<MechanicalAndHardwareGroupListDto> GetAll();
    long Insert(MechanicalAndHardwareGroupDto dto);
    void Update(MechanicalAndHardwareGroupDto dto);
    void Delete(long id);
}

