namespace ThermaCore.Application.DTOs.Management;

public class LoginResultDto
{
    public bool IsSuccess { get; set; }
    public long UserId { get; set; }
    public string TenantConnectionString { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
}
