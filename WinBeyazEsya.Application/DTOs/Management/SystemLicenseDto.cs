using System;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Management;

public class SystemLicenseDto : BaseDto
{
    public string ServerHardwareId { get; set; } = string.Empty;
    public string LicenseKey { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public int MaxTerminalCount { get; set; }
}

