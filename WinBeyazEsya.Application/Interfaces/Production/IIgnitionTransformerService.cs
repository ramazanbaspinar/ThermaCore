using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IIgnitionTransformerService
{
    IgnitionTransformerDto GetById(long id);
    IEnumerable<IgnitionTransformerListDto> GetAll();
    long Insert(IgnitionTransformerDto dto);
    void Update(IgnitionTransformerDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

