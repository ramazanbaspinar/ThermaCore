using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Interfaces.Security;

public interface ILicenseService
{
    LicenseStatus CheckLicense(out string message);
}

