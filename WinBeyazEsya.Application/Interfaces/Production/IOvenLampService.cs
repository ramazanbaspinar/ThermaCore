using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IOvenLampService
{
    OvenLampDto GetById(long id);
    IEnumerable<OvenLampListDto> GetAll();
    IEnumerable<OvenLampListDto> GetAllList();
    IEnumerable<OvenLampListDto> GetActiveList();
    long Insert(OvenLampDto dto);
    void Update(OvenLampDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

