using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Entities.Security;

namespace ThermaCore.Application.Services.Management;

public class AuthManager : IAuthService
{
    private readonly IMasterRepository<User> _userRepository;
    private readonly IMasterRepository<TenantDatabase> _tenantRepository;
    private readonly IMasterRepository<Terminal> _terminalRepository;
    private readonly IMasterRepository<UserTenant> _userTenantRepository;
    private readonly IMasterRepository<UserBranch> _userBranchRepository;
    private readonly IMasterRepository<Branch> _branchRepository;
    private readonly IMasterRepository<RolePermission> _rolePermissionRepository;
    private readonly ThermaCore.Application.Interfaces.System.ICurrentTenantService _currentTenantService;
    private readonly ICryptoService _cryptoService;
    private readonly IMapper _mapper;

    public AuthManager(
        IMasterRepository<User> userRepository,
        IMasterRepository<TenantDatabase> tenantRepository,
        IMasterRepository<Terminal> terminalRepository,
        IMasterRepository<UserTenant> userTenantRepository,
        IMasterRepository<UserBranch> userBranchRepository,
        IMasterRepository<Branch> branchRepository,
        IMasterRepository<RolePermission> rolePermissionRepository,
        ThermaCore.Application.Interfaces.System.ICurrentTenantService currentTenantService,
        ICryptoService cryptoService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _tenantRepository = tenantRepository;
        _terminalRepository = terminalRepository;
        _userTenantRepository = userTenantRepository;
        _userBranchRepository = userBranchRepository;
        _branchRepository = branchRepository;
        _rolePermissionRepository = rolePermissionRepository;
        _currentTenantService = currentTenantService;
        _cryptoService = cryptoService;
        _mapper = mapper;
    }

    public Task<List<TenantDatabaseDto>> GetAllowedTenantsByUsernameAsync(string username)
    {
        var user = _userRepository.Find(u => u.Code.ToLower() == username.ToLower() && u.IsActive).FirstOrDefault();
        if (user == null)
            return Task.FromResult(new List<TenantDatabaseDto>());

        // Admin ise tüm aktif şirketleri listele
        if (username.ToLower() == "admin" || username.ToLower() == "thermacore")
        {
            var allTenants = _tenantRepository.Find(t => t.IsActive).ToList();
            return Task.FromResult(_mapper.Map<List<TenantDatabaseDto>>(allTenants));
        }

        // Kullanıcının yetkili olduğu şirketleri getir
        var userTenantIds = _userTenantRepository.Find(ut => ut.UserId == user.Id && ut.IsActive).Select(ut => ut.TenantDatabaseId).ToList();
        
        var tenants = _tenantRepository.Find(t => t.IsActive && userTenantIds.Contains(t.Id)).ToList();
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

        var info = ThermaCore.Domain.Helpers.NetworkHelper.GetHardwareFingerprints();
        var allActiveMacs = info.AllMacs;

        if (!allActiveMacs.Any())
        {
            throw new global::System.Exception("Cihazınızda aktif bir ağ bağdaştırıcısı bulunamadı. Lütfen ağ bağlantınızı kontrol edin.");
        }

        var terminals = _terminalRepository.Find(t => t.IsActive).ToList();
        
        bool hasAccess = false;
        foreach (var mac in allActiveMacs)
        {
            if (terminals.Any(t => t.EthernetMacAddress == mac || t.WifiMacAddress == mac || t.VpnMacAddress == mac))
            {
                hasAccess = true;
                break;
            }
        }

        if (!hasAccess)
        {
            string macListStr = string.Join(", ", allActiveMacs);
            throw new global::System.Exception($"Güvenlik İhlali: Bu cihaz (Mevcut MAC Adresleri: {macListStr}) sisteme kayıtlı değil veya aktif edilmemiş. Giriş reddedildi.");
        }

        return Task.FromResult(true);
    }

    public Task<List<BranchDto>> GetAllowedBranchesAsync(long userId, long tenantId)
    {
        var user = _userRepository.Find(u => u.Id == userId && u.IsActive).FirstOrDefault();
        if (user == null)
            return Task.FromResult(new List<BranchDto>());

        // Admin ise veya thermacore ise o tenant'ın tüm şubelerini dön
        if (user.Code.ToLower() == "admin" || user.Code.ToLower() == "thermacore")
        {
            var allBranches = _branchRepository.Find(b => b.TenantDatabaseId == tenantId && b.IsActive).ToList();
            return Task.FromResult(_mapper.Map<List<BranchDto>>(allBranches));
        }

        var allowedBranchIds = _userBranchRepository
            .Find(ub => ub.UserId == userId && ub.IsActive)
            .Select(ub => ub.BranchId)
            .ToList();

        var branches = _branchRepository
            .Find(b => allowedBranchIds.Contains(b.Id) && b.TenantDatabaseId == tenantId && b.IsActive)
            .ToList();

        return Task.FromResult(_mapper.Map<List<BranchDto>>(branches));
    }

    public bool HasPermission(ThermaCore.Domain.Enums.ModuleType moduleType, ThermaCore.Domain.Enums.PermissionType permissionType)
    {
        long userId = _currentTenantService.UserId;
        if (userId <= 0) return false;

        var user = _userRepository.Find(u => u.Id == userId).FirstOrDefault();
        if (user == null) return false;

        // Admin veya thermacore tam yetkili
        if (user.Code.ToLower() == "admin" || user.Code.ToLower() == "thermacore")
            return true;

        long tenantId = _currentTenantService.TenantId;


        // Rol bazlı yetki kontrolü
        long roleId = user.UserRoleId;
        int moduleId = (int)moduleType;

        var rolePermission = _rolePermissionRepository.Find(rp => 
            rp.RoleId == roleId && 
            rp.ModuleId == moduleId).FirstOrDefault();

        if (rolePermission == null)
            return false;

        return permissionType switch
        {
            ThermaCore.Domain.Enums.PermissionType.CanView => rolePermission.CanRead,
            ThermaCore.Domain.Enums.PermissionType.CanAdd => rolePermission.CanCreate,
            ThermaCore.Domain.Enums.PermissionType.CanEdit => rolePermission.CanUpdate,
            ThermaCore.Domain.Enums.PermissionType.CanDelete => rolePermission.CanDelete,
            _ => false
        };
    }
}
