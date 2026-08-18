using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Common;

public class SpecialCode : FullAuditableEntity, IMustHaveBranch
{
    public SpecialCodeType CodeType { get; set; }
    public string EntityType { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public long BranchId { get; set; }
}

