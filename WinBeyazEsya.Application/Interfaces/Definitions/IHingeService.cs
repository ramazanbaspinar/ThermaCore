using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IHingeService
{
    HingeDto GetById(long id);
    IEnumerable<HingeListDto> GetAll();
    long Insert(HingeDto dto);
    void Update(HingeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

