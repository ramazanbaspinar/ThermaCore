using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class ColorFeatureDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public long BranchId { get; set; }
}

