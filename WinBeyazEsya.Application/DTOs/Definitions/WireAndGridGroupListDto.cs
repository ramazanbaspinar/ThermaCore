using System;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class WireAndGridGroupListDto : BaseDto
{
    public string Name { get; set; } = null!;
    
    public long BaseUnitId { get; set; }
    public string BaseUnitName { get; set; } = string.Empty;

    public long? SpecialCodeId { get; set; }
    
    public string? CoatingType { get; set; }
    public string? MaterialType { get; set; }
    
    public string? Description { get; set; }
}
