using System;
using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class TerminalDto : BaseDto
{
    public string HardwareId { get; set; } = string.Empty;
    public string? Description { get; set; }

}
