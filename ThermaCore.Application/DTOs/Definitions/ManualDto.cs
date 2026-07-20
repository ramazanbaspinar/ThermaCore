using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Definitions;

public class ManualDto : BaseDto
{
    // Id, Code, IsActive are inherited from BaseDto and MUST NOT be hidden!
    
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public ManualType? ManualType { get; set; }
    public PaperType? PaperType { get; set; }
    public LanguageCode? LanguageCode { get; set; }
    
    public int? PageCount { get; set; }
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
}
