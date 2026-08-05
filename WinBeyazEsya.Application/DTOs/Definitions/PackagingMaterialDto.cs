using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class PackagingMaterialDto : BaseDto
{
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public PackagingType? PackagingType { get; set; }
    public PackagingMaterialType? PackagingMaterialType { get; set; }
    
    public decimal? ThicknessMm { get; set; }
    public decimal? WeightGr { get; set; }
    
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
}

