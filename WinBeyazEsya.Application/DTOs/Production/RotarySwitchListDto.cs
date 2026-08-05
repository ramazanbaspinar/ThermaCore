using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class RotarySwitchListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? CurrentAmper { get; set; }
    public int? Voltage { get; set; }
    public string? Position { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string? SpecialCodeName { get; set; }
}

