using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IHandleService
{
    IEnumerable<HandleListDto> GetAll();
    HandleDto GetById(long id);
    long Insert(HandleDto dto);
    void Update(HandleDto dto);
    void Delete(long id);
}

