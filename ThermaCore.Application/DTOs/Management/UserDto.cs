using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class UserDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public long UserRoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    
    public List<UserTenantDto> UserTenants { get; set; } = new();
    public List<UserBranchDto> UserBranches { get; set; } = new();
}
