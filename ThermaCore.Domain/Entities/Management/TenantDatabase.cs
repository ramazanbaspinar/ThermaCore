using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Management;

public class TenantDatabase : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [Required]
    [MaxLength(10)]
    public string CompanyCode { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string DatabaseName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string Server { get; set; } = string.Empty;
    
    public AuthenticationType AuthType { get; set; }
    
    [MaxLength(100)]
    public string? Username { get; set; }
    
    [MaxLength(1000)]
    public string? Password { get; set; }
}
