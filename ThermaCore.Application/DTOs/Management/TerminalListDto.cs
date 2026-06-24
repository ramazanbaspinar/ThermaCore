using System;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class TerminalListDto : BaseDto
{
    public string DeviceName { get; set; } = string.Empty;
    public string HardwareId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string HardwareFingerprint { get; set; } = string.Empty;
    public DateTime? LastLoginDate { get; set; }
}
