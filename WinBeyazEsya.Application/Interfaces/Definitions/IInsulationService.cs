using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IInsulationService
{
    global::System.Collections.Generic.IEnumerable<InsulationListDto> GetAll();
    InsulationDto GetById(long id);
    long Insert(InsulationDto dto);
    void Update(InsulationDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

