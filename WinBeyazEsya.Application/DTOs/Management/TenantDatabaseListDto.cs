using WinBeyazEsya.Domain.Enums;

using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Management;

public class TenantDatabaseListDto : BaseDto
{
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    
    public string CompanyCode { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string Server { get; set; } = string.Empty;
    public AuthenticationType AuthType { get; set; }
}

