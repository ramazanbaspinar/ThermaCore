using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IOvenTimerService
{
    OvenTimerDto GetById(long id);
    IEnumerable<OvenTimerListDto> GetAll();
    long Insert(OvenTimerDto dto);
    void Update(OvenTimerDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

