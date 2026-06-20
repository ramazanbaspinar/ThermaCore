using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Services.Management;

public class AuthManager : IAuthService
{
    private readonly IMasterRepository<User> _userRepository;
    private readonly IMasterRepository<TenantDatabase> _tenantRepository;
    private readonly IMasterRepository<Terminal> _terminalRepository;
    private readonly ICryptoService _cryptoService;
    private readonly IMapper _mapper;

    public AuthManager(
        IMasterRepository<User> userRepository,
        IMasterRepository<TenantDatabase> tenantRepository,
        IMasterRepository<Terminal> terminalRepository,
        ICryptoService cryptoService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _tenantRepository = tenantRepository;
        _terminalRepository = terminalRepository;
        _cryptoService = cryptoService;
        _mapper = mapper;
    }

    public Task<List<TenantDatabaseDto>> GetAllowedTenantsByUsernameAsync(string username)
    {
        // Şimdilik sistemdeki tüm aktif şirketler dönülüyor.
        // TODO: İleride yetki (M2M) tablosu eklendiğinde Admin değilse sadece yetkili olduğu şirketler dönülecek.
        var user = _userRepository.Find(u => u.Code.ToLower() == username.ToLower() && u.IsActive).FirstOrDefault();
        if (user == null)
            return Task.FromResult(new List<TenantDatabaseDto>());

        // Admin ise tüm aktif şirketleri listele
        if (username.ToLower() == "admin")
        {
            var allTenants = _tenantRepository.Find(t => t.IsActive).ToList();
            return Task.FromResult(_mapper.Map<List<TenantDatabaseDto>>(allTenants));
        }

        // İleride normal kullanıcılar için M2M UserTenant sorgusu gelecek, şimdilik hepsi
        var tenants = _tenantRepository.Find(t => t.IsActive).ToList();
        return Task.FromResult(_mapper.Map<List<TenantDatabaseDto>>(tenants));
    }

    public Task<LoginResultDto> LoginAsync(string username, string password, long tenantId)
    {
        var result = new LoginResultDto();

        var user = _userRepository.Find(u => u.Code == username && u.IsActive).FirstOrDefault();
        if (user == null)
        {
            result.IsSuccess = false;
            result.ErrorMessage = "Kullanıcı bulunamadı veya hesabı pasif durumda.";
            return Task.FromResult(result);
        }

        if (!ThermaCore.Domain.Helpers.PasswordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            result.IsSuccess = false;
            result.ErrorMessage = "Hatalı şifre.";
            return Task.FromResult(result);
        }

        var tenant = _tenantRepository.GetById(tenantId);
        if (tenant == null || !tenant.IsActive)
        {
            result.IsSuccess = false;
            result.ErrorMessage = "Seçilen şirket bulunamadı veya pasif.";
            return Task.FromResult(result);
        }

        result.IsSuccess = true;
        result.UserId = user.Id;
        
        // TenantDatabase nesnesinden dinamik ConnectionString oluşturulması
        // Güvenlik gereği AuthType'a göre Windows Authentication veya SQL Authentication stringi oluşturulabilir.
        string decryptedPassword = string.IsNullOrEmpty(tenant.Password) ? "" : _cryptoService.Decrypt(tenant.Password);
        result.TenantConnectionString = $"Server={tenant.Server};Database={tenant.DatabaseName};User Id={tenant.Username};Password={decryptedPassword};TrustServerCertificate=True;";

        return Task.FromResult(result);
    }

    public Task<bool> CheckTerminalAccessAsync(string username, string hardwareFingerprint, long tenantId)
    {
        // thermacore (SuperAdmin) kullanıcısı için terminal kontrolünü atla (Bypass)
        if (username.ToLower() == "thermacore")
            return Task.FromResult(true);

        var terminal = _terminalRepository
            .Find(t => t.HardwareFingerprint == hardwareFingerprint && t.IsActive)
            .FirstOrDefault();

        return Task.FromResult(terminal != null);
    }
}
