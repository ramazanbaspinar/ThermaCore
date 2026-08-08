using System;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ElectricalElectronicGroupListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnitName { get; set; } = string.Empty;
    public string? Description { get; set; }
}
