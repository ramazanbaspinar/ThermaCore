using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Management;

public class TenantDatabaseDto : BaseDto
{
    public string CompanyCode { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string Server { get; set; } = string.Empty;
    public AuthenticationType AuthType { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}
