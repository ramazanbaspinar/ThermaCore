using System;
using System.Linq;
using ThermaCore.Application.DTOs.Security;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Security
{
    public class LicenseValidator : ILicenseValidator
    {
        private readonly IMasterRepository<UserSession> _userSessionRepository;

        public LicenseValidator(IMasterRepository<UserSession> userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }

        public LicenseDataDto ValidateLicense(string licenseKey)
        {
            // TODO: İleride gerçek bir RSA asimetrik şifre çözme eklenecek.
            // Şimdilik Mock (Taslak) olarak çalışmaktadır.
            var dto = new LicenseDataDto();

            if (string.IsNullOrWhiteSpace(licenseKey))
            {
                dto.IsValid = false;
                dto.ErrorMessage = "Lisans anahtarı boş olamaz.";
                return dto;
            }

            try
            {
                // Mock: RSA Private/Public Key ile şifre çözüldüğünü varsayıyoruz.
                // İlerleyen süreçte burada gerçek Keygen ve RSACryptoServiceProvider kullanılacak.
                
                dto.MacAddress = "Mock-Mac-Address";
                dto.ExpirationDate = DateTime.Now.AddDays(365);
                dto.MaxTerminalCount = 5;
                dto.IsValid = true;
                dto.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                dto.IsValid = false;
                dto.ErrorMessage = "Lisans çözümlenemedi. Geçersiz Lisans Anahtarı. Hata: " + ex.Message;
            }

            return dto;
        }

        public bool IsTimeTampered()
        {
            try
            {
                // Veritabanındaki en son oturum/işlem kaydının tarihini alıyoruz.
                var lastSession = _userSessionRepository.GetAll()
                    .OrderByDescending(x => x.CreatedDate)
                    .FirstOrDefault();

                if (lastSession != null)
                {
                    // Eğer işletim sistemi saati, sistemdeki son kayıttan daha eskiyse (zaman geriye alınmışsa)
                    if (DateTime.Now < lastSession.CreatedDate)
                    {
                        return true; // Zaman manipüle edilmiş (Tampered)
                    }
                }

                return false;
            }
            catch
            {
                // Veritabanına erişilemezse veya başka bir hata olursa şimdilik güvenli kabul et
                return false; 
            }
        }
    }
}
