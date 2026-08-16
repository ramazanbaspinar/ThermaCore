using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class CountryDto : BaseDto
{
    public long LogicalRef { get; set; }
    public string Title { get; set; } = string.Empty;
}
