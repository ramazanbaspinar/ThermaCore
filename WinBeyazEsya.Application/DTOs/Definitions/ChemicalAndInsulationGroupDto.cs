using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ChemicalAndInsulationGroupDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public long BaseUnitId { get; set; }
    public long? SpecialCodeId { get; set; }
    public string? Description { get; set; }
}
