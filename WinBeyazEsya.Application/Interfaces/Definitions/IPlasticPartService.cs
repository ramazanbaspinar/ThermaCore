using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions
{
    public interface IPlasticPartService
    {
        IEnumerable<PlasticPartListDto> GetAll();
        PlasticPartDto GetById(long id);
        long Insert(PlasticPartDto dto);
        void Update(PlasticPartDto dto);
        void Delete(long id);
    }
}

