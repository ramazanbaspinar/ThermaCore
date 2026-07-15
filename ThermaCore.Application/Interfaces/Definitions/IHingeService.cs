using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Base;
using System.Collections.Generic;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IHingeService
{
    HingeDto GetById(long id);
    IEnumerable<HingeListDto> GetAll();
    long Insert(HingeDto dto);
    void Update(HingeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
