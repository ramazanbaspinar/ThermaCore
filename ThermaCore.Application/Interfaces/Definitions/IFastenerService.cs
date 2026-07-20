using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions
{
    public interface IFastenerService
    {
        IEnumerable<FastenerListDto> GetAll();
        FastenerDto GetById(long id);
        long Insert(FastenerDto dto);
        void Update(FastenerDto dto);
        void Delete(long id);
    }
}
