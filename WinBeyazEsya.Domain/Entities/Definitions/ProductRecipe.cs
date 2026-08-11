using System.Collections.Generic;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class ProductRecipe : FullAuditableEntity, IMustHaveBranch
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    
    public long FinishedGoodId { get; set; }
    public virtual FinishedGood FinishedGood { get; set; } = null!;

    public string? Description { get; set; }
    public string RevisionNumber { get; set; } = "01";

    public long BranchId { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<ProductRecipeLine> Lines { get; set; } = new List<ProductRecipeLine>();
}
