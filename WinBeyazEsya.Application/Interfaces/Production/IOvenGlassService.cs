using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IOvenGlassService
{
    OvenGlassDto GetById(long id);
    IEnumerable<OvenGlassListDto> GetAll();
    long Insert(OvenGlassDto dto);
    void Update(OvenGlassDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

