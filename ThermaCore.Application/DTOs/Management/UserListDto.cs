using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class UserListDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    // Joint with UserRole
    public string RoleName { get; set; } = string.Empty; 
}
