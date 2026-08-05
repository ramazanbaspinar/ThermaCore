using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Production;

public class GasPipeListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? Diameter { get; set; }
    public decimal? LengthMm { get; set; }
    public int? BranchCount { get; set; }
    public PipeType? PipeType { get; set; }
    public GasType? GasType { get; set; }
    public string? Description { get; set; }
}

