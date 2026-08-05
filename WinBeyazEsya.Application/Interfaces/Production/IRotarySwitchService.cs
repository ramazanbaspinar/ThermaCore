using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IRotarySwitchService
{
    RotarySwitchDto GetById(long id);
    IEnumerable<RotarySwitchListDto> GetAll();
    long Insert(RotarySwitchDto dto);
    void Update(RotarySwitchDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

