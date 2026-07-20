using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class LockListDto : BaseDto
{
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public string? LockType { get; set; }
    public string? MaterialType { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    public string? SpecialCodeCode { get; set; }
}
