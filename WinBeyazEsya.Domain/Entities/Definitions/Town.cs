using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class Town : FullAuditableEntity
{
    public long LogicalRef { get; set; }
    public string Code { get; set; } = string.Empty;

    
    
    public string Title { get; set; } = string.Empty;

    public long CityId { get; set; }

    
    public string? CityCode { get; set; }

    
    public string? TownCode { get; set; }

    public bool IsActive { get; set; } = true;
}
