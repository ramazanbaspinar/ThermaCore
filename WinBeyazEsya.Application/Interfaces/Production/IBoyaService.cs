using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IBoyaService
{
    BoyaDto GetById(long id);
    IEnumerable<BoyaListDto> GetAll();
    long Insert(BoyaDto dto);
    void Update(BoyaDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

