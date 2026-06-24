using System;
using System.Linq;
using ThermaCore.Application.DTOs.Security;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Domain.Entities.System;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

namespace ThermaCore.Infrastructure.Security
{
    public class LicenseValidator : ILicenseValidator
    {
        private readonly IMasterRepository<UserSession> _userSessionRepository;

        public LicenseValidator(IMasterRepository<UserSession> userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }

        private const string DummyPublicKey = @"<RSAKeyValue><Modulus>s74R/aD018zC29x9GzH/R3XF6QnS1e7xP9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4N8P9B+G8A3N9D+K3A4Nw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        public LicenseDataDto ValidateLicense(string licenseKey)
        {
            var dto = new LicenseDataDto();

            if (string.IsNullOrWhiteSpace(licenseKey))
            {
                dto.IsValid = false;
                dto.ErrorMessage = "Lisans anahtarı boş olamaz.";
                return dto;
            }

            try
            {
                var licenseWrapper = JsonSerializer.Deserialize<LicenseWrapperDto>(licenseKey);
                if (licenseWrapper == null || licenseWrapper.alg != "RSA-SHA256" || string.IsNullOrEmpty(licenseWrapper.payload) || string.IsNullOrEmpty(licenseWrapper.signature))
                {
                    throw new Exception("Geçersiz lisans formatı.");
                }

                byte[] payloadBytes = Convert.FromBase64String(licenseWrapper.payload);
                byte[] signatureBytes = Convert.FromBase64String(licenseWrapper.signature);

                using (var rsa = new RSACryptoServiceProvider())
                {
                    // Sınıfın içine geçici bir Public Key (XML String) sabiti kondu.
                    rsa.FromXmlString(DummyPublicKey);
                    
                    bool isVerified = false;
                    try
                    {
                        isVerified = rsa.VerifyData(payloadBytes, CryptoConfig.MapNameToOID("SHA256")!, signatureBytes);
                    }
                    catch
                    {
                        isVerified = false;
                    }

                    if (!isVerified)
                    {
                        throw new Exception("Lisans imzası geçersiz. Veriler değiştirilmiş olabilir!");
                    }
                }

                string payloadJson = Encoding.UTF8.GetString(payloadBytes);
                var licenseData = JsonSerializer.Deserialize<LicensePayloadData>(payloadJson);

                if (licenseData == null)
                    throw new Exception("Payload deserialize edilemedi.");

                dto.MacAddress = licenseData.MachineFingerprint;
                dto.ExpirationDate = licenseData.ExpiryUtc;
                dto.MaxTerminalCount = licenseData.Seats;
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

        private class LicenseWrapperDto
        {
            public string alg { get; set; } = string.Empty;
            public string payload { get; set; } = string.Empty;
            public string signature { get; set; } = string.Empty;
        }

        private class LicensePayloadData
        {
            public int Seats { get; set; }
            public DateTime ExpiryUtc { get; set; }
            public string MachineFingerprint { get; set; } = string.Empty;
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
