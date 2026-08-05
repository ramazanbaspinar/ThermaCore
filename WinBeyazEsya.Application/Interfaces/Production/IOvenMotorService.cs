using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IOvenMotorService
{
    OvenMotorDto GetById(long id);
    IEnumerable<OvenMotorListDto> GetAllList();
    IEnumerable<OvenMotorListDto> GetActiveList();
    long Insert(OvenMotorDto dto);
    void Update(OvenMotorDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

