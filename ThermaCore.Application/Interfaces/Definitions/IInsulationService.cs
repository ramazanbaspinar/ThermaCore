using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IInsulationService
{
    global::System.Collections.Generic.IEnumerable<InsulationListDto> GetAll();
    InsulationDto GetById(long id);
    long Insert(InsulationDto dto);
    void Update(InsulationDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
