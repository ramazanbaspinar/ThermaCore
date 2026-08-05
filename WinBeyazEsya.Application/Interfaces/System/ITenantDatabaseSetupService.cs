using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Interfaces.System;

public interface ITenantDatabaseSetupService
{
    Task CreateTenantDatabaseAsync(TenantDatabaseDto tenant);
}

