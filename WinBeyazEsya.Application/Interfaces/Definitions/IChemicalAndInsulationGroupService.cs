using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IChemicalAndInsulationGroupService
{
    ChemicalAndInsulationGroupDto GetById(long id);
    IEnumerable<ChemicalAndInsulationGroupListDto> GetAll();
    long Insert(ChemicalAndInsulationGroupDto dto);
    void Update(ChemicalAndInsulationGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(string code, long id = 0);
}
