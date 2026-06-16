using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class UserRoleListDto : BaseDto
{
    public string RoleName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
