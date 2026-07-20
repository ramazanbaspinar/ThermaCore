using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class FastenerListDto : BaseDto
{
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public string? FastenerType { get; set; }
    public string? MaterialType { get; set; }
    
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    public string? SpecialCode { get; set; }
    public string? Standard { get; set; }
}
