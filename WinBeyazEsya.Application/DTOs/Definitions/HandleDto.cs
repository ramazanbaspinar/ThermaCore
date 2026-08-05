using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class HandleDto : BaseDto
{
    // YASAK: Id, Code ve IsActive alanları yeniden tanımlanmayacak (Gizleme yasağı)
    
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public HandleType? HandleType { get; set; }
    public MaterialType? MaterialType { get; set; }
    public string? Color { get; set; }
    public decimal? LengthMm { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
}

