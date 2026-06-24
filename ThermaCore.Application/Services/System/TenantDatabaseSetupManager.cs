using System.Threading.Tasks;
using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using FluentValidation;

namespace ThermaCore.Application.Services.System;

public class TenantDatabaseSetupManager : ITenantDatabaseSetupService
{
    private readonly IMasterRepository<TenantDatabase> _repository;
    private readonly IMapper _mapper;
    private readonly ITenantDatabaseService _tenantDatabaseService;
    private readonly ICryptoService _cryptoService;
    private readonly IMasterUnitOfWork _uow;
    private readonly IValidator<TenantDatabaseDto> _validator;

    public TenantDatabaseSetupManager(
        IMasterRepository<TenantDatabase> repository,
        IMapper mapper,
        ITenantDatabaseService tenantDatabaseService,
        ICryptoService cryptoService,
        IMasterUnitOfWork uow,
        IValidator<TenantDatabaseDto> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _tenantDatabaseService = tenantDatabaseService;
        _cryptoService = cryptoService;
        _uow = uow;
        _validator = validator;
    }

    public async Task CreateTenantDatabaseAsync(TenantDatabaseDto tenant)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(tenant);
        }

        string masterConnectionString = $"Server={tenant.Server};Database=master;TrustServerCertificate=True;Encrypt=False;";
        if (tenant.AuthType == AuthenticationType.Windows)
        {
            masterConnectionString += "Integrated Security=True;";
        }
        else
        {
            masterConnectionString += $"User Id={tenant.Username};Password={tenant.Password};Integrated Security=False;";
        }

        bool dbExists = await _tenantDatabaseService.CheckDatabaseExistsAsync(masterConnectionString, tenant.DatabaseName);
        if (dbExists)
        {
            throw new global::System.Exception($"Belirttiğiniz '{tenant.DatabaseName}' veritabanı, '{tenant.Server}' sunucusunda zaten mevcut. Lütfen yeni bir veritabanı adı belirleyiniz.");
        }

        string connectionString = $"Server={tenant.Server};Database={tenant.DatabaseName};TrustServerCertificate=True;Encrypt=False;";

        if (tenant.AuthType == AuthenticationType.Windows)
        {
            connectionString += "Integrated Security=True;";
        }
        else
        {
            connectionString += $"User Id={tenant.Username};Password={tenant.Password};Integrated Security=False;";
        }

        if (tenant.CompanyCode == "MASTER")
        {
            // İlk kurulumda Master veritabanı oluşturuluyor. SADECE Master tabloları olmalı.
            await _tenantDatabaseService.CreateMasterDatabaseAsync(connectionString);
        }
        else
        {
            // Yeni bir şirket (Tenant) ekleniyor. SADECE Tenant tabloları oluşturulmalı.
            await _tenantDatabaseService.CreateDatabaseAsync(connectionString);
        }

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
