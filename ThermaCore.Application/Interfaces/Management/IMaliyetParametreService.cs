using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Interfaces.Management;

public interface IMaliyetParametreService
{
    Task<MaliyetParametreDto> GetMaliyetParametreAsync();
    Task SaveParametreAsync(MaliyetParametreDto dto);
}
