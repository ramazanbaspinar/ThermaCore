using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IHeatingElementService
{
    HeatingElementDto GetById(long id);
    IEnumerable<HeatingElementListDto> GetAll();
    long Insert(HeatingElementDto dto);
    void Update(HeatingElementDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
