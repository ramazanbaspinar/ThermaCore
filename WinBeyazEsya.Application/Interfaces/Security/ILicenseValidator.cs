using System;
using WinBeyazEsya.Application.DTOs.Security;

namespace WinBeyazEsya.Application.Interfaces.Security
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

