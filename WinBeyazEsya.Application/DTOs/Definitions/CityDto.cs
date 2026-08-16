using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class CityDto : BaseDto
{
    public long LogicalRef { get; set; }
    public string Title { get; set; } = string.Empty;
    public long CountryId { get; set; }
    public string? CountryCode { get; set; }
}
