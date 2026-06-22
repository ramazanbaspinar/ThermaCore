using System;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class TerminalDto : BaseDto
{
    public string DeviceName { get; set; } = string.Empty;
    public string MacAddress { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string HardwareFingerprint { get; set; } = string.Empty;
    public string LicenseKey { get; set; } = string.Empty;
    public DateTime? LastLoginDate { get; set; }
}
