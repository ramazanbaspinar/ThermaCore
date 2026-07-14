using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IInjectorService
{
    InjectorDto GetById(long id);
    IEnumerable<InjectorListDto> GetAll();
    long Insert(InjectorDto dto);
    void Update(InjectorDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
