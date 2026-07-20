using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IManualService
{
    IEnumerable<ManualListDto> GetAll();
    ManualDto GetById(long id);
    long Insert(ManualDto dto);
    void Update(ManualDto dto);
    void Delete(long id);
}
