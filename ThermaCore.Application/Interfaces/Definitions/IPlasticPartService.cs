using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions
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
