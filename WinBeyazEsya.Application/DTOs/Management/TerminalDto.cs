using System;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Management;

public class TerminalDto : BaseDto
{
    public string HardwareId { get; set; } = string.Empty;
    public string? Description { get; set; }

}

