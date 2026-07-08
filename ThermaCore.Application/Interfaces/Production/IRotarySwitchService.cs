using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IRotarySwitchService
{
    RotarySwitchDto GetById(long id);
    IEnumerable<RotarySwitchListDto> GetAll();
    long Insert(RotarySwitchDto dto);
    void Update(RotarySwitchDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
