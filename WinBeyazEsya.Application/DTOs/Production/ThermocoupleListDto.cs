using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class ThermocoupleListDto : BaseDto
{
    // Id, Code, IsActive are inherited from BaseDto and MUST NOT be hidden!
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public decimal? LengthMm { get; set; }
    public string? HeadType { get; set; }
    public string? TipType { get; set; }
    public string? Description { get; set; }

    public string? SpecialCodeCode { get; set; }
}

