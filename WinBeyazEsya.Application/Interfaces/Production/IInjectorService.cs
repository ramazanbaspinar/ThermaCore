using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IInjectorService
{
    InjectorDto GetById(long id);
    IEnumerable<InjectorListDto> GetAll();
    long Insert(InjectorDto dto);
    void Update(InjectorDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

