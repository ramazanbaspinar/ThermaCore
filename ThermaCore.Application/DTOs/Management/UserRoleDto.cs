using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class UserRoleDto : BaseDto
{
    public string RoleName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
