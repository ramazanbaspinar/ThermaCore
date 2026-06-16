using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Interfaces.Security;

public interface ILicenseService
{
    LicenseStatus CheckLicense(out string message);
}
