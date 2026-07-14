using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IIgnitionTransformerService
{
    IgnitionTransformerDto GetById(long id);
    IEnumerable<IgnitionTransformerListDto> GetAll();
    long Insert(IgnitionTransformerDto dto);
    void Update(IgnitionTransformerDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
