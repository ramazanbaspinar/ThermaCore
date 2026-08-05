using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IManualService
{
    IEnumerable<ManualListDto> GetAll();
    ManualDto GetById(long id);
    long Insert(ManualDto dto);
    void Update(ManualDto dto);
    void Delete(long id);
}

