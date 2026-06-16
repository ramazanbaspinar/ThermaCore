using System.Linq;
using System.Threading.Tasks;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Yonetim;
using ThermaCore.Infrastructure.Persistence;

namespace ThermaCore.Infrastructure.System;

public class DatabaseSeederManager : IDatabaseSeederService
{
    private readonly ThermaCoreContext _context;
    private readonly ICryptoService _cryptoService;

    public DatabaseSeederManager(ThermaCoreContext context, ICryptoService cryptoService)
    {
        _context = context;
        _cryptoService = cryptoService;
    }

    public async Task SeedAsync(bool ilIlceYuklensin)
    {
        await _context.Database.EnsureCreatedAsync();

        if (!_context.KullaniciRolleri.Any(r => r.RolAdi == "Sistem Yöneticisi"))
        {
            var adminRol = new KullaniciRolu
            {
                RolAdi = "Sistem Yöneticisi",
                Aciklama = "Sistemin en yetkili rolüdür. Tüm modüllere tam erişimi vardır.",
                Durum = true
            };
            
            _context.KullaniciRolleri.Add(adminRol);
            await _context.SaveChangesAsync();

            if (!_context.Kullanicilar.Any(k => k.Kod == "ADMIN"))
            {
                var adminKullanici = new Kullanici
                {
                    Kod = "ADMIN",
                    Adi = "Sistem",
                    Soyadi = "Yöneticisi",
                    Email = "admin@thermacore.com",
                    Sifre = _cryptoService.EncryptMd5("thermacore"),
                    KullaniciRoluId = adminRol.Id,
                    Durum = true
                };
                
                _context.Kullanicilar.Add(adminKullanici);
                await _context.SaveChangesAsync();
            }
        }

        if (ilIlceYuklensin)
        {
            // İleride 81 ilin temel insert işlemleri buraya eklenecektir.
        }
    }
}
