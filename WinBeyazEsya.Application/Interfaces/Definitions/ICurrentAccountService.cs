using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ICurrentAccountService : IBaseService
{
    CurrentAccountDto GetById(long id);
    IEnumerable<CurrentAccountDto> GetAll();
    long Insert(CurrentAccountDto dto);
    void Update(CurrentAccountDto dto);
    void Delete(long id);
}
