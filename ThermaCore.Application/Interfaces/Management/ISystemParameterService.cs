using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Interfaces.Management;

public interface ISystemParameterService
{
    Task<SystemParameterDto> GetSystemParameterAsync();
    Task SaveParameterAsync(SystemParameterDto dto);
}
