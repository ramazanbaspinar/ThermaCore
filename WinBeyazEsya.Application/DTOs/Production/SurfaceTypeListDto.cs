using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class SurfaceTypeListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}

