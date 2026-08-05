using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class IgnitionTransformerDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public int? OutputCount { get; set; }
    public string? Voltage { get; set; }
    public string? Frequency { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
}

