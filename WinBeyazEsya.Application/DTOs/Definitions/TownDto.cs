using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class TownDto : BaseDto
{
    public long LogicalRef { get; set; }
    public string Title { get; set; } = string.Empty;
    public long CityId { get; set; }
    public string? CityCode { get; set; }
    public string? TownCode { get; set; }
}
