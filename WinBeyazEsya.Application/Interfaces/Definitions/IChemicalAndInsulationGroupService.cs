using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IChemicalAndInsulationGroupService : IBaseService
{
    ChemicalAndInsulationGroupDto GetById(long id);
    IEnumerable<ChemicalAndInsulationGroupListDto> GetAll();
    long Insert(ChemicalAndInsulationGroupDto dto);
    void Update(ChemicalAndInsulationGroupDto dto);
    void Delete(long id);
}


