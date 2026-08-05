using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class KnobListDto : BaseDto
{

    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? Color { get; set; }
    public string? ShaftType { get; set; }
    public string? Description { get; set; }


    public string? SpecialCode { get; set; }
}

