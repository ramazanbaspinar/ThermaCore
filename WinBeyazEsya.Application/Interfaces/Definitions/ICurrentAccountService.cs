using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ICurrentAccountService : IBaseService
{
    CurrentAccountDto GetById(long id);
    IEnumerable<CurrentAccountDto> GetAll();
    long Insert(CurrentAccountDto dto);
    void Update(CurrentAccountDto dto);
    void Delete(long id);
}
