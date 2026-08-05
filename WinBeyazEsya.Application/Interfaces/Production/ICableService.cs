using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface ICableService
{
    CableDto GetById(long id);
    IEnumerable<CableListDto> GetAll();
    long Insert(CableDto dto);
    void Update(CableDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

