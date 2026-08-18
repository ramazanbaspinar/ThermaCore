using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Infrastructure.Security;

public class LicenseService : ILicenseService
{
    private readonly IHardwareInfoService _hardwareInfoService;
    private readonly ILicenseValidator _licenseValidator;
    private readonly IMasterRepository<SystemLicense> _licenseRepo;

    public LicenseService(IHardwareInfoService hardwareInfoService, ILicenseValidator licenseValidator, IMasterRepository<SystemLicense> licenseRepo)
    {
        _hardwareInfoService = hardwareInfoService;
        _licenseValidator = licenseValidator;
        _licenseRepo = licenseRepo;
    }

    public LicenseStatus CheckLicense(out string message)
    {
        var activeLicense = _licenseRepo.Find(x => true).FirstOrDefault();
        if (activeLicense == null)
        {
            message = "Lisans bulunamadı.";
            return LicenseStatus.Invalid;
        }

        var result = _licenseValidator.ValidateLicense(activeLicense.LicenseKey);
        if (result.IsValid)
        {
            var remaining = (result.ExpirationDate - DateTime.UtcNow).TotalDays;
            int days = (int)Math.Max(0, Math.Ceiling(remaining));
            message = days.ToString();
            return LicenseStatus.Valid;
        }

        message = result.ErrorMessage;
        return LicenseStatus.Expired;
    }
}

