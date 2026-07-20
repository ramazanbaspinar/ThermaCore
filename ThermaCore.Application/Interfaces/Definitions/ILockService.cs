using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface ILockService
{
    IEnumerable<LockListDto> GetAll();
    LockDto GetById(long id);
    long Insert(LockDto dto);
    void Update(LockDto dto);
    void Delete(long id);
}
