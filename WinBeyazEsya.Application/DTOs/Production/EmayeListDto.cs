using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class EmayeListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? Description { get; set; }
    public long? SpecialCodeId { get; set; }
    public string? SpecialCodeName { get; set; }
}

