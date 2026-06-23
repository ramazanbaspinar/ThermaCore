using System;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class TerminalDto : BaseDto
{
    public string DeviceName { get; set; } = string.Empty;
    public string EthernetMacAddress { get; set; } = string.Empty;
    public string WifiMacAddress { get; set; } = string.Empty;
    public string VpnMacAddress { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}
