using System;
using ThermaCore.Application.DTOs.Security;

namespace ThermaCore.Application.Interfaces.Security
{
    public interface ILicenseValidator
    {
        LicenseDataDto ValidateLicense(string licenseKey);
        bool IsTimeTampered();
    }
}
