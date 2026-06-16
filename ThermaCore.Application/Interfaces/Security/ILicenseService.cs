using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Interfaces.Security;

public interface ILicenseService
{
    LisansDurumu CheckLicense(out string message);
}
