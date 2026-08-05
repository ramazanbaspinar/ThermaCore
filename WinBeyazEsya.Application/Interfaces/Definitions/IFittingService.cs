using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IFittingService
{
    IEnumerable<FittingListDto> GetAll();
    FittingDto GetById(long id);
    long Insert(FittingDto dto);
    void Update(FittingDto dto);
    void Delete(long id);
}

