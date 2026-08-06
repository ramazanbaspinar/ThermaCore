using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Common;

public class SpecialCodeDto : BaseDto
{
    public SpecialCodeType CodeType { get; set; }
    public string EntityType { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public long BranchId { get; set; }
}

