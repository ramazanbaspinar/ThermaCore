using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ILockService
{
    IEnumerable<LockListDto> GetAll();
    LockDto GetById(long id);
    long Insert(LockDto dto);
    void Update(LockDto dto);
    void Delete(long id);
}

