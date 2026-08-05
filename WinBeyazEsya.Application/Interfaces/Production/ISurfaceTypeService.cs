using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface ISurfaceTypeService
{
    SurfaceTypeDto GetById(long id);
    IEnumerable<SurfaceTypeListDto> GetAll();
    long Insert(SurfaceTypeDto dto);
    void Update(SurfaceTypeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

