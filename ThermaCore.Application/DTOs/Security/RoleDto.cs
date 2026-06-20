using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Security;

public class RoleDto : BaseDto
{
    public string RoleName { get; set; } = null!;
    public string? Description { get; set; }
}
