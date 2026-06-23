using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Infrastructure.Persistence;

namespace ThermaCore.Infrastructure.System;

public class DatabaseSeederManager : IDatabaseSeederService
{
    private readonly ThermaCoreMasterContext _context;
    private readonly ICryptoService _cryptoService;

    public DatabaseSeederManager(ThermaCoreMasterContext context, ICryptoService cryptoService)
    {
        _context = context;
        _cryptoService = cryptoService;
    }

    public async Task SeedAsync(bool ilIlceYuklensin)
    {
        var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
        
        if (pendingMigrations.Any())
        {
            throw new global::System.Exception("Veritabanı güncel değil. Uygulamanın çalışabilmesi için sistem yöneticisi tarafından veritabanı güncellemesi yapılması gerekmektedir.");
        }

        var appliedMigrations = await _context.Database.GetAppliedMigrationsAsync();
        var localMigrations = _context.Database.GetMigrations();
        if (appliedMigrations.Except(localMigrations).Any())
        {
            throw new global::System.Exception("Kullandığınız uygulama sürümü eskidir. Lütfen uygulamanızı güncelleyin.");
        }

        long adminRolId = 0;
        var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "System Administrator");
        
        ThermaCore.Domain.Entities.Security.Role? selectedRole = existingRole;

        if (existingRole == null)
        {
            var adminRol = new ThermaCore.Domain.Entities.Security.Role
            {
                Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                Code = "ADMIN_ROLE",
                RoleName = "System Administrator",
                Description = "The most authorized role in the system. Full access to all modules.",
                IsActive = true
            };
            
            _context.Roles.Add(adminRol);
            await _context.SaveChangesAsync();
            adminRolId = adminRol.Id;
            selectedRole = adminRol;
        }
        else
        {
            adminRolId = existingRole.Id;
        }

        if (!_context.Users.Any(k => k.Code.ToLower() == "thermacore"))
        {
            if (adminRolId > 0 && selectedRole != null)
            {
                ThermaCore.Domain.Helpers.PasswordHasher.CreatePasswordHash("thermacore!", out byte[] hash, out byte[] salt);
                var adminKullanici = new User
                {
                    Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                    Code = "thermacore",
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@thermacore.com",
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserRoleId = adminRolId,
                    Role = selectedRole,
                    IsActive = true
                };
                
                _context.Users.Add(adminKullanici);
                await _context.SaveChangesAsync();
            }
        }

        if (!_context.TenantDatabases.Any(t => t.CompanyCode == "000"))
        {
            var defaultTenant = new TenantDatabase
            {
                Id = 1,
                Code = "000",
                CompanyCode = "000",
                CompanyName = "ThermaCore",
                DatabaseName = "ThermaCore_Tenant_000",
                Server = "(localdb)\\MSSQLLocalDB",
                AuthType = ThermaCore.Domain.Enums.AuthenticationType.SqlServer,
                Username = "sa",
                Password = _cryptoService.Encrypt("sa"),
                IsActive = true
            };

            _context.TenantDatabases.Add(defaultTenant);
            await _context.SaveChangesAsync();
        }

        if (ilIlceYuklensin)
        {
            // Future database seed operations
        }
    }
}
