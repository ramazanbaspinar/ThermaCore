using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface ISurfaceTypeService
{
    SurfaceTypeDto GetById(long id);
    IEnumerable<SurfaceTypeListDto> GetAll();
    long Insert(SurfaceTypeDto dto);
    void Update(SurfaceTypeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
