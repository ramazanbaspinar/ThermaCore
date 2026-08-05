using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Interfaces.Management;

public interface ISystemParameterService
{
    Task<SystemParameterDto> GetSystemParameterAsync();
    Task SaveParameterAsync(SystemParameterDto dto);
}

