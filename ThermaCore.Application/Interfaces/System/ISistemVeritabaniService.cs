using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Yonetim;

namespace ThermaCore.Application.Interfaces.System;

public interface ISistemVeritabaniService
{
    Task CreateTenantDatabaseAsync(SistemVeritabaniDto tenant);
}
