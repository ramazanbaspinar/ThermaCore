using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IMaterialCostService
{
    MaterialCostDto GetById(long id);
    IEnumerable<MaterialCostListDto> GetAll();
    IEnumerable<MaterialCostListDto> GetAllByMaterialType(ModuleType type);
    long Insert(MaterialCostDto dto);
    void Update(MaterialCostDto dto);
    void Delete(long id);
}

