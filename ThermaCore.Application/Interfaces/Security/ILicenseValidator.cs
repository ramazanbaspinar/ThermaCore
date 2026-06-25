using System;
using ThermaCore.Application.DTOs.Security;

namespace ThermaCore.Application.Interfaces.Security
{
    public interface ILicenseValidator
    {
        LicenseDataDto ValidateLicense(string licenseKey);
        LicenseDataDto ValidateLicense(string licenseKey, bool isActivation);
        bool IsTimeTampered(bool isActivation = false);
        void UpdateLastKnownGoodTime();
        void ResetTimeCheat();
    }
}
