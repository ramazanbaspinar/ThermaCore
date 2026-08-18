using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class ChemicalAndInsulationGroup : FullAuditableEntity, IMustHaveBranch
{
    public long BranchId { get; set; }

    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public string? Description { get; set; }

    public long? BaseUnitId { get; set; }
    public Unit? BaseUnit { get; set; }

    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }
}
