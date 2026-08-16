using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class Country : FullAuditableEntity
{
    public long LogicalRef { get; set; }
    public string Code { get; set; } = string.Empty;

    
    
    public string Title { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
