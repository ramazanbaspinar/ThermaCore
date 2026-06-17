using System.Threading.Tasks;
using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Services.System;

public class TenantDatabaseSetupManager : ITenantDatabaseSetupService
{
    private readonly IMasterRepository<TenantDatabase> _repository;
    private readonly IMapper _mapper;
    private readonly ITenantDatabaseService _tenantDatabaseService;
    private readonly ICryptoService _cryptoService;
    private readonly IMasterUnitOfWork _uow;

    public TenantDatabaseSetupManager(
        IMasterRepository<TenantDatabase> repository,
        IMapper mapper,
        ITenantDatabaseService tenantDatabaseService,
        ICryptoService cryptoService,
        IMasterUnitOfWork uow)
    {
        _repository = repository;
        _mapper = mapper;
        _tenantDatabaseService = tenantDatabaseService;
        _cryptoService = cryptoService;
        _uow = uow;
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

        if (_repository != null && _uow != null && _cryptoService != null && _mapper != null)
        {
            // Şifreyi veritabanına düz metin yazmamak için şifreliyoruz
            var entity = _mapper.Map<TenantDatabase>(tenant);
            entity.Password = string.IsNullOrEmpty(tenant.Password) ? "" : _cryptoService.Encrypt(tenant.Password);
            
            _repository.Add(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
