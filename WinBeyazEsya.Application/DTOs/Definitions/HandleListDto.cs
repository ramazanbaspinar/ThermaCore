using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class HandleListDto : BaseDto
{
    // YASAK: Id, Code ve IsActive alanları yeniden tanımlanmayacak (Gizleme yasağı)
    
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? HandleTypeName { get; set; }
    public string? MaterialTypeName { get; set; }
    public string? Color { get; set; }
    public decimal? LengthMm { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    public string? SpecialCodeName { get; set; }
}

