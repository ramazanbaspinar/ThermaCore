using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IPackagingMaterialService
{
    IEnumerable<PackagingMaterialListDto> GetAll();
    PackagingMaterialDto GetById(long id);
    long Insert(PackagingMaterialDto dto);
    void Update(PackagingMaterialDto dto);
    void Delete(long id);
}
