using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Infrastructure.Persistence;

namespace WinBeyazEsya.Infrastructure.System;

public class DatabaseSeederManager : IDatabaseSeederService
{
    private readonly WinBeyazEsyaMasterContext _context;
    private readonly ICryptoService _cryptoService;

    public DatabaseSeederManager(WinBeyazEsyaMasterContext context, ICryptoService cryptoService)
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
        
        WinBeyazEsya.Domain.Entities.Security.Role? selectedRole = existingRole;

        if (existingRole == null)
        {
            var adminRol = new WinBeyazEsya.Domain.Entities.Security.Role
            {
                Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                Code = "WINBEYAZESYA_ROLE",
                RoleName = "System Administrator",
                Description = "",
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

        if (!_context.Users.Any(k => k.Code.ToLower() == "winbeyazesya"))
        {
            if (adminRolId > 0 && selectedRole != null)
            {
                WinBeyazEsya.Domain.Helpers.PasswordHasher.CreatePasswordHash("winbeyazesyayonetim!", out byte[] hash, out byte[] salt);
                var adminKullanici = new User
                {
                    Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                    Code = "winbeyazesya",
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "info@winbeyazesya.com",
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
            var defaultTenant = new WinBeyazEsya.Domain.Entities.Management.TenantDatabase
            {
                Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                Code = "000",
                CompanyCode = "000",
                CompanyName = "WinBeyazEsya Demo A.Ş.",
                DatabaseName = "WinBeyazEsya_Tenant_000",
                Server = "(localdb)\\MSSQLLocalDB",
                AuthType = WinBeyazEsya.Domain.Enums.AuthenticationType.SqlServer,
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



