using System.Threading.Tasks;
using AutoMapper;

using ThermaCore.Application.DTOs.Yonetim;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Yonetim;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Services.System;

public class SistemVeritabaniManager : ISistemVeritabaniService
{
    private readonly IMasterRepository<SistemVeritabani> _repository;
    private readonly IMapper _mapper;
    private readonly ITenantDatabaseService _tenantDatabaseService;

    public SistemVeritabaniManager(
        IMasterRepository<SistemVeritabani> repository,
        IMapper mapper,
        ITenantDatabaseService tenantDatabaseService)
    {
        _repository = repository;
        _mapper = mapper;
        _tenantDatabaseService = tenantDatabaseService;
    }

    public async Task CreateTenantDatabaseAsync(SistemVeritabaniDto tenant)
    {
        string connectionString = $"Server={tenant.Server};Database={tenant.VeritabaniAdi};TrustServerCertificate=True;Encrypt=False;";

        if (tenant.YetkilendirmeTuru == YetkilendirmeTuru.Windows)
        {
            connectionString += "Integrated Security=True;";
        }
        else
        {
            connectionString += $"User Id={tenant.KullaniciAdi};Password={tenant.Sifre};Integrated Security=False;";
        }

        // Sadece Tenant veritabanını oluştur, Seeding yapma
        await _tenantDatabaseService.CreateDatabaseAsync(connectionString);
    }
}
