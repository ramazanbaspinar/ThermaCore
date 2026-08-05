using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class Manual : FullAuditableEntity
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;
    
    public bool IsActive { get; set; } = true;
    
    public ManualType? ManualType { get; set; }
    public PaperType? PaperType { get; set; }
    public LanguageCode? LanguageCode { get; set; }
    
    public int? PageCount { get; set; }
    
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }
}

