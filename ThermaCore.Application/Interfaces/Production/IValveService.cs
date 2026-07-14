using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IValveService
{
    ValveDto GetById(long id);
    IEnumerable<ValveListDto> GetAll();
    long Insert(ValveDto dto);
    void Update(ValveDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
