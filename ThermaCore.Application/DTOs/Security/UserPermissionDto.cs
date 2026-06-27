using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Security;

public class UserPermissionDto : BaseDto
{
    public long UserId { get; set; }
    public int ModuleId { get; set; }
    public int ParentId { get; set; }
    public string ModuleName { get; set; } = null!;
    
    public bool CanRead { get; set; }
    public bool CanCreate { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }

    public string? SpecialPermissions { get; set; }
}
