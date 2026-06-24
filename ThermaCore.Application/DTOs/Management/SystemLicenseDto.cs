using System;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class SystemLicenseDto : BaseDto
{
    public string ServerMacAddress { get; set; } = string.Empty;
    public string ServerCpuId { get; set; } = string.Empty;
    public string LicenseKey { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
}
