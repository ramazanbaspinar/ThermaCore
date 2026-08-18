using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class GasAndIgnitionGroupDto : BaseDto
{
    public string Name { get; set; } = null!;

    public long BaseUnitId { get; set; }
    public string BaseUnitName { get; set; } = string.Empty;

    public long? SpecialCodeId { get; set; }

    public string? Description { get; set; }
}
