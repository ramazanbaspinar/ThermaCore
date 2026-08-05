using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class ProductLabelDto : BaseDto
{
    // Id, Code, IsActive properties are inherited from BaseDto
    
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public LabelType? LabelType { get; set; }
    public LabelMaterialType? LabelMaterialType { get; set; }
    
    public decimal? WidthMm { get; set; }
    public decimal? HeightMm { get; set; }
    
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
}

