using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Interfaces.System;

public interface ITenantDatabaseSetupService
{
    Task CreateTenantDatabaseAsync(TenantDatabaseDto tenant);
}
