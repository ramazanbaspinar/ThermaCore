using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IGlassTypeService
{
    GlassTypeDto GetById(long id);
    IEnumerable<GlassTypeListDto> GetAll();
    long Insert(GlassTypeDto dto);
    void Update(GlassTypeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

