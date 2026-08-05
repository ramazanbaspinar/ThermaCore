using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Interfaces.Management;

public interface IMaliyetParametreService
{
    Task<MaliyetParametreDto> GetMaliyetParametreAsync();
    Task SaveParametreAsync(MaliyetParametreDto dto);
}

