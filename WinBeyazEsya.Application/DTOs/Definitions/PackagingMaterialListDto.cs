using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class PackagingMaterialListDto : BaseDto
{
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public string? PackagingType { get; set; }
    public string? PackagingMaterialType { get; set; }
    
    public decimal? ThicknessMm { get; set; }
    public decimal? WeightGr { get; set; }
    
    public string? Description { get; set; }
    
    public string? SpecialCode { get; set; }
}

