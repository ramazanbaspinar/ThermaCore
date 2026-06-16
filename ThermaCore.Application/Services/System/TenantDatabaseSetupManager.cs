using System.Threading.Tasks;
using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Services.System;

public class TenantDatabaseSetupManager : ITenantDatabaseSetupService
{
    private readonly IMasterRepository<TenantDatabase> _repository;
    private readonly IMapper _mapper;
    private readonly ITenantDatabaseService _tenantDatabaseService;

    public TenantDatabaseSetupManager(
        IMasterRepository<TenantDatabase> repository,
        IMapper mapper,
        ITenantDatabaseService tenantDatabaseService)
    {
        _repository = repository;
        _mapper = mapper;
        _tenantDatabaseService = tenantDatabaseService;
    }

    public async Task CreateTenantDatabaseAsync(TenantDatabaseDto tenant)
    {
        string connectionString = $"Server={tenant.Server};Database={tenant.DatabaseName};TrustServerCertificate=True;Encrypt=False;";

        if (tenant.AuthType == AuthenticationType.Windows)
        {
            connectionString += "Integrated Security=True;";
        }
        else
        {
            connectionString += $"User Id={tenant.Username};Password={tenant.Password};Integrated Security=False;";
        }

        // Create Master Database, don't seed
        await _tenantDatabaseService.CreateMasterDatabaseAsync(connectionString);
    }
}
