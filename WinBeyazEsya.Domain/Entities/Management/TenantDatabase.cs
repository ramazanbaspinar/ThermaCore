using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Management;

public class TenantDatabase : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [Required]
    [MaxLength(100)]
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

