using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IThermocoupleService
{
    ThermocoupleDto GetById(long id);
    List<ThermocoupleListDto> GetAll();
    ThermocoupleDto Add(ThermocoupleDto dto);
    ThermocoupleDto Update(ThermocoupleDto dto);
    void Delete(long id);
    string GetCode();
}
