using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IEmayeService
{
    EmayeDto GetById(long id);
    IEnumerable<EmayeListDto> GetAll();
    long Insert(EmayeDto dto);
    void Update(EmayeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

