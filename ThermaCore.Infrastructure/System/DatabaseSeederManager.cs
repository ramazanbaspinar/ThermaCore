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
                Code = "ADMIN_ROLE",
                RoleName = "System Administrator",
                Description = "The most authorized role in the system. Full access to all modules.",
                IsActive = true
            };
            
            _context.UserRoles.Add(adminRol);
            await _context.SaveChangesAsync();

            if (!_context.Users.Any(k => k.Code == "ADMIN"))
            {
                var adminKullanici = new User
                {
                    Code = "ADMIN",
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@thermacore.com",
                    Password = _cryptoService.EncryptMd5("thermacore"),
                    UserRoleId = adminRol.Id,
                    IsActive = true
                };
                
                _context.Users.Add(adminKullanici);
                await _context.SaveChangesAsync();
            }
        }

        if (ilIlceYuklensin)
        {
            // Future database seed operations
        }
    }
}
