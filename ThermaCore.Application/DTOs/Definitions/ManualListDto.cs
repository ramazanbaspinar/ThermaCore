using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Definitions;

public class ManualListDto : BaseDto
{
    // Id, Code, IsActive are inherited from BaseDto and MUST NOT be hidden!
    
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public string? ManualType { get; set; }
    public string? PaperType { get; set; }
    public string? LanguageCode { get; set; }
    
    public int? PageCount { get; set; }
    public string? Description { get; set; }
    
    public string? SpecialCodeName { get; set; }
}
