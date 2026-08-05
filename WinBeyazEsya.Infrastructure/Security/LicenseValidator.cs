using System;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Security;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Domain.Entities.System;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

namespace WinBeyazEsya.Infrastructure.Security
{
    public class LicenseValidator : ILicenseValidator
    {
        private readonly IMasterRepository<UserSession> _userSessionRepository;
        private readonly IMasterRepository<WinBeyazEsya.Domain.Entities.Management.SystemLicense> _licenseRepository;
        private readonly IMasterUnitOfWork _uow;

        public LicenseValidator(
            IMasterRepository<UserSession> userSessionRepository, 
            IMasterRepository<WinBeyazEsya.Domain.Entities.Management.SystemLicense> licenseRepository,
            IMasterUnitOfWork uow)
        {
            _userSessionRepository = userSessionRepository;
            _licenseRepository = licenseRepository;
            _uow = uow;
        }

        private const string DummyPublicKey = @"<RSAKeyValue><Modulus>1KdTdgfVtbluGQk10dBYsO5rfaz53V6hfT7RVU3kGnxo6wmSl2jI6cL5eGA2XHV0j0FM6osUfNGoNq6C+ct2nFKteIo2YkMHs9YLGSWUCR77VqHSq+Lofg3m58D+WI1632L3f4piX/Te2FfOrEyP8O/ZC2o8p4kwq7G0wlqUXn1LrAlEhmQn54iQiBQ6gObwthgZr1Autd4TFl9eOs2srP+BZNlx1k1aMEsAjNNHLJLypVwKhlLoPlbWS1uEjhsMrD8YWBeS9ZceTt5H+/7bPLu8Cr3fjFcpoXnshwHoh+Rgfm8DfR6HfNjZvg6haH6AM7BELCXzWznrBEFhgFbAxQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        private string FixBase64Padding(string base64)
        {
            int mod4 = base64.Length % 4;
            if (mod4 > 0)
            {
                base64 += new string('=', 4 - mod4);
            }
            return base64;
        }

        public LicenseDataDto ValidateLicense(string licenseKey) => ValidateLicense(licenseKey, false);

        public LicenseDataDto ValidateLicense(string licenseKey, bool isActivation)
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
                LicenseWrapperDto? licenseWrapper;
                try
                {
                    licenseWrapper = JsonSerializer.Deserialize<LicenseWrapperDto>(licenseKey);
                }
                catch
                {
                    throw new Exception("Geçersiz Lisans Formatı. Lütfen size verilen metni eksiksiz kopyaladığınızdan emin olun.");
                }

                if (licenseWrapper == null || licenseWrapper.alg != "RSA-SHA256" || string.IsNullOrEmpty(licenseWrapper.payload) || string.IsNullOrEmpty(licenseWrapper.signature))
                {
                    throw new Exception("Geçersiz Lisans Formatı. Lütfen size verilen metni eksiksiz kopyaladığınızdan emin olun.");
                }

                string sanitizedPayload = FixBase64Padding(licenseWrapper.payload.Trim().Replace(" ", "").Replace("\r", "").Replace("\n", ""));
                string sanitizedSignature = FixBase64Padding(licenseWrapper.signature.Trim().Replace(" ", "").Replace("\r", "").Replace("\n", ""));

                byte[] payloadBytes = Convert.FromBase64String(sanitizedPayload);
                byte[] signatureBytes = Convert.FromBase64String(sanitizedSignature);

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

                if (DateTime.UtcNow > licenseData.ExpiryUtc)
                {
                    dto.IsValid = false;
                    dto.ErrorMessage = $"Lisans süreniz {licenseData.ExpiryUtc.ToLocalTime():dd.MM.yyyy} tarihinde dolmuştur! Lütfen yenileyiniz.";
                    return dto;
                }

                if (IsTimeTampered(isActivation) && !(isActivation && licenseData.ResetTimeCheat))
                {
                    dto.IsValid = false;
                    dto.ErrorMessage = "Sistem saati manipülasyonu (Time-Cheat) veya Sahtekarlık Girişimi tespit edildi! Lisans kilitlendi.";
                    return dto;
                }

                dto.MacAddress = licenseData.MachineFingerprint;
                dto.ExpirationDate = licenseData.ExpiryUtc;
                dto.MaxTerminalCount = licenseData.Seats;
                dto.ResetTimeCheat = licenseData.ResetTimeCheat;
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
            public bool ResetTimeCheat { get; set; }
        }

        private class LkgtPayloadDto
        {
            public DateTime LkgtDate { get; set; }
            public string LicenseKeyHash { get; set; } = string.Empty;
            public long LastSessionId { get; set; }
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string GetLkgtFilePath()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string folder = global::System.IO.Path.Combine(appData, "WinBeyazEsya");
            if (!global::System.IO.Directory.Exists(folder)) global::System.IO.Directory.CreateDirectory(folder);
            return global::System.IO.Path.Combine(folder, "system.sig");
        }

        public bool IsTimeTampered(bool isActivation = false)
        {
            try
            {
                var activeLicense = _licenseRepository.Find(x => true).FirstOrDefault();
                if (activeLicense == null)
                {
                    return false; // Sıfır kurulum durumu (Lisans yok), manipülasyon olamaz.
                }

                string currentHwid = WinBeyazEsya.Domain.Helpers.HardwareInfoHelper.GetHWID();
                if (currentHwid != activeLicense.ServerHardwareId)
                {
                    // Bu cihaz bir İstemci (Client). Zaman kalkanı sadece Ana Sunucuda çalışır.
                    return false;
                }

                // 1. Veritabanındaki en son oturum/işlem kaydının tarihini alıyoruz.
                var lastSession = _userSessionRepository.GetAll()
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                if (lastSession != null)
                {
                    if (DateTime.Now < lastSession.CreatedDate)
                    {
                        return true; // Zaman manipüle edilmiş (DB)
                    }
                }

                // 2. Kriptografik İşletim Sistemi Katmanı (LKGT)
                string lkgtFile = GetLkgtFilePath();

                if (!global::System.IO.File.Exists(lkgtFile))
                {
                    if (activeLicense != null && !isActivation)
                    {
                        return true; // DOSYA YOK ETME (DELETION) SALDIRISI: Lisans var ama dosya yoksa kilitler!
                    }
                    return false;
                }

                byte[] encryptedData = global::System.IO.File.ReadAllBytes(lkgtFile);
                byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.LocalMachine);
                string jsonStr = Encoding.UTF8.GetString(decryptedData);
                
                var lkgtDto = JsonSerializer.Deserialize<LkgtPayloadDto>(jsonStr);
                if (lkgtDto != null)
                {
                    if (DateTime.UtcNow < lkgtDto.LkgtDate)
                    {
                        return true; // Zaman manipüle edilmiş (LKGT)
                    }

                    // YEDEK-GERİ YÜKLEME (BACKUP-RESTORE) SALDIRISI KORUMASI:
                    if (activeLicense != null)
                    {
                        string currentHash = ComputeSha256Hash(activeLicense.LicenseKey);
                        if (lkgtDto.LicenseKeyHash != currentHash)
                        {
                            return true; // Dosyadaki lisans ile DB'deki lisans uyuşmuyor!
                        }
                    }

                    long currentMaxId = lastSession != null ? lastSession.Id : 0;
                    if (lkgtDto.LastSessionId != currentMaxId)
                    {
                        return true; // YEDEK-GERİ YÜKLEME SALDIRISI: Dosya ile DB uyuşmuyor!
                    }
                }

                return false;
            }
            catch
            {
                return true; 
            }
        }

        public void UpdateLastKnownGoodTime()
        {
            try
            {
                var activeLicenseCheck = _licenseRepository.Find(x => true).FirstOrDefault();
                if (activeLicenseCheck != null)
                {
                    string currentHwid = WinBeyazEsya.Domain.Helpers.HardwareInfoHelper.GetHWID();
                    if (currentHwid != activeLicenseCheck.ServerHardwareId)
                    {
                        // Bu cihaz bir İstemci (Client). Zaman kalkanı güncellenmez.
                        return;
                    }
                }

                string lkgtFile = GetLkgtFilePath();
                if (global::System.IO.File.Exists(lkgtFile))
                {
                    global::System.IO.File.Delete(lkgtFile);
                }
                
                var lastSession = _userSessionRepository.GetAll()
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                var activeLicense = _licenseRepository.Find(x => true).FirstOrDefault();

                var dto = new LkgtPayloadDto
                {
                    LkgtDate = DateTime.UtcNow,
                    LicenseKeyHash = activeLicense != null ? ComputeSha256Hash(activeLicense.LicenseKey) : string.Empty,
                    LastSessionId = lastSession != null ? lastSession.Id : 0
                };

                string jsonStr = JsonSerializer.Serialize(dto);
                byte[] data = Encoding.UTF8.GetBytes(jsonStr);
                byte[] encryptedData = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);
                global::System.IO.File.WriteAllBytes(lkgtFile, encryptedData);
            }
            catch (Exception ex)
            {
                // SUSTURMA (READ-ONLY) SALDIRISI KORUMASI:
                throw new Exception("Güvenlik modülü başlatılamadı veya dosya erişimi engellendi! Lütfen yetkileri kontrol edin. Hata: " + ex.Message);
            }
        }

        public void ResetTimeCheat()
        {
            try
            {
                // A) Veritabanındaki hatalı/gelecek zamanlı kayıtları temizle (HARD DELETE)
                var futuristicSessions = _userSessionRepository.Find(x => 
                    x.CreatedDate > DateTime.Now || 
                    x.LoginTime > DateTime.Now || 
                    (x.ModifiedDate.HasValue && x.ModifiedDate.Value > DateTime.Now)
                ).ToList();
                
                foreach (var session in futuristicSessions)
                {
                    _userSessionRepository.Remove(session);
                }
                
                // NOT: _uow.SaveChanges() burada ÇAĞRILMIYOR.
                // Çift katmanlı commit (transaction) güvenliği için LicenseActivationForm içerisinde çağrılacaktır.

                // B) Kriptografik LKGT dosyasını güncelle
                UpdateLastKnownGoodTime();
            }
            catch { }
        }
    }
}

