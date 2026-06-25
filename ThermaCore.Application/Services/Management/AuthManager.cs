using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Entities.Security;
using ThermaCore.Domain.Entities.System;

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
    private readonly IMasterRepository<UserSession> _userSessionRepository;
    private readonly IMasterUnitOfWork _uow;
    private readonly ThermaCore.Application.Interfaces.System.ICurrentTenantService _currentTenantService;
    private readonly ICryptoService _cryptoService;
    private readonly IMapper _mapper;
    private readonly IMasterRepository<SystemLicense> _licenseRepository;
    private readonly ILicenseValidator _licenseValidator;

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
        IMapper mapper,
        IMasterRepository<UserSession> userSessionRepository,
        IMasterUnitOfWork uow,
        IMasterRepository<SystemLicense> licenseRepository,
        ILicenseValidator licenseValidator)
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
        _userSessionRepository = userSessionRepository;
        _uow = uow;
        _licenseRepository = licenseRepository;
        _licenseValidator = licenseValidator;
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

        // Update Terminal IP/Mac is replaced with HWID validation. Terminal IP/Mac tracking is removed.

        // Add User Session
        var session = new UserSession
        {
            Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
            UserId = user.Id,
            LoginTime = global::System.DateTime.Now,
            IpAddress = ThermaCore.Domain.Helpers.NetworkHelper.GetLocalIpAddress(),
            ComputerName = global::System.Environment.MachineName,
            Status = ThermaCore.Domain.Enums.SessionStatus.Active,
            CreatedUserId = user.Id,
            CreatedDate = global::System.DateTime.Now
        };
        _userSessionRepository.Add(session);
        _uow.SaveChanges();

        // Store Session Id in result to be handled by Presentation layer
        result.SessionId = session.Id;

        // Başarılı giriş yapıldığında LKGT dosyasını güncelle
        _licenseValidator.UpdateLastKnownGoodTime();

        return Task.FromResult(result);
    }

    public Task<bool> CheckTerminalAccessAsync(string username, string hardwareFingerprint, long tenantId)
    {
        // thermacore (SuperAdmin) kullanıcısı için terminal kontrolünü atla (Bypass)
        if (username.ToLower() == "thermacore")
            return Task.FromResult(true);

        string hwid = ThermaCore.Domain.Helpers.HardwareInfoHelper.GetHWID();

        if (string.IsNullOrEmpty(hwid))
        {
            throw new global::System.Exception("Cihazınızda donanım kimliği (HWID) üretilemedi. Lütfen yetkiliyle iletişime geçin.");
        }

        var terminals = _terminalRepository.Find(t => t.IsActive).ToList();
        
        bool hasAccess = terminals.Any(t => t.HardwareId == hwid);

        if (!hasAccess)
        {
            int maxTerminalCount = 0;
            var license = _licenseRepository.Find(x => true).FirstOrDefault();
            if (license != null)
            {
                maxTerminalCount = license.MaxTerminalCount;
            }

            if (terminals.Count >= maxTerminalCount)
            {
                throw new global::System.Exception("Lisansınızın izin verdiği maksimum terminal (cihaz) sınırına ulaşıldı!");
            }

            throw new global::System.Exception($"Güvenlik İhlali: Bu cihaz (HWID: {hwid}) sisteme kayıtlı değil veya aktif edilmemiş. Giriş reddedildi.");
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
