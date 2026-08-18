using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IWarehouseService : IBaseService
{
    WarehouseDto GetById(long id);
    IEnumerable<WarehouseListDto> GetAll();
    long Insert(WarehouseDto dto);
    void Update(WarehouseDto dto);
    void Delete(long id);
}
