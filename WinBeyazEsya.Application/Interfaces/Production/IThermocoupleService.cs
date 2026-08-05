using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IThermocoupleService
{
    ThermocoupleDto GetById(long id);
    List<ThermocoupleListDto> GetAll();
    ThermocoupleDto Add(ThermocoupleDto dto);
    ThermocoupleDto Update(ThermocoupleDto dto);
    void Delete(long id);

}

