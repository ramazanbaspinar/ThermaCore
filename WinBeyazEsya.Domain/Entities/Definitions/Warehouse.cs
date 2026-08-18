using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class Warehouse : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? AuthorizedPerson { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
