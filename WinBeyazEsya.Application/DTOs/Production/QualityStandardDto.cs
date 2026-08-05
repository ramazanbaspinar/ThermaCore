using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Production;

public class QualityStandardDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public MaterialGroup MaterialGroup { get; set; }
    public string? Description { get; set; }
}

