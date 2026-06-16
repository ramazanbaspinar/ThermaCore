using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Infrastructure.Security;

public class LicenseService : ILicenseService
{
    private readonly IHardwareInfoService _hardwareInfoService;

    public LicenseService(IHardwareInfoService hardwareInfoService)
    {
        _hardwareInfoService = hardwareInfoService;
    }

    public LicenseStatus CheckLicense(out string message)
    {
        var fingerprint = _hardwareInfoService.GetMachineFingerprint();
        
        message = "Lisans geçerli. Donanım Parmak İzi: " + fingerprint;
        return LicenseStatus.Valid;
    }
}
