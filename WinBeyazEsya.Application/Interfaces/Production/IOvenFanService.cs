using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IOvenFanService
{
    OvenFanDto GetById(long id);
    IEnumerable<OvenFanListDto> GetAllList();
    IEnumerable<OvenFanListDto> GetActiveList();
    long Insert(OvenFanDto dto);
    void Update(OvenFanDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

