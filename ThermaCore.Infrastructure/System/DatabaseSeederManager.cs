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
        await _context.Database.EnsureCreatedAsync();

        if (!_context.UserRoles.Any(r => r.RoleName == "System Administrator"))
        {
            var adminRol = new UserRole
            {
                Id = 1,
                Code = "ADMIN_ROLE",
                RoleName = "System Administrator",
                Description = "The most authorized role in the system. Full access to all modules.",
                IsActive = true
            };
            
            _context.UserRoles.Add(adminRol);
            await _context.SaveChangesAsync();

            if (!_context.Users.Any(k => k.Code.ToLower() == "thermacore"))
            {
                var adminKullanici = new User
                {
                    Id = 1,
                    Code = "thermacore",
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@thermacore.com",
                    Password = _cryptoService.EncryptMd5("thermacore!"),
                    UserRoleId = adminRol.Id,
                    IsActive = true
                };
                
                _context.Users.Add(adminKullanici);
                await _context.SaveChangesAsync();
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
        }

        if (ilIlceYuklensin)
        {
            // Future database seed operations
        }
    }
}
