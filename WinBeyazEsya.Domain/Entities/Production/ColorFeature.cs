using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Production;

public class ColorFeature : FullAuditableEntity, IMustHaveBranch
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public long BranchId { get; set; }
}

