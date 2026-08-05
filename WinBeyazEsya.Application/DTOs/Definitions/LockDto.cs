using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class LockDto : BaseDto
{
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;

    public LockType? LockType { get; set; }
    public MaterialType? MaterialType { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
}

