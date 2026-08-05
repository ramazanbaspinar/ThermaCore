using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Production;

public class GasPipe : FullAuditableEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string? Diameter { get; set; }
    public decimal? LengthMm { get; set; }
    public int? BranchCount { get; set; }
    public PipeType? PipeType { get; set; }
    public GasType? GasType { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public long? SpecialCodeId { get; set; }

    public virtual SpecialCode? SpecialCode { get; set; }
}

