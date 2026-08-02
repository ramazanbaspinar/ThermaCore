using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Interfaces.Production;

public interface IMaterialCostService
{
    MaterialCostDto GetById(long id);
    IEnumerable<MaterialCostListDto> GetAll();
    IEnumerable<MaterialCostListDto> GetAllByMaterialType(ModuleType type);
    long Insert(MaterialCostDto dto);
    void Update(MaterialCostDto dto);
    void Delete(long id);
}
