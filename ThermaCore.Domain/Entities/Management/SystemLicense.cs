using System;
using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Management;

public class SystemLicense : AuditableEntity
{
    [MaxLength(100)]
    public string ServerMacAddress { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string ServerCpuId { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string LicenseKey { get; set; } = string.Empty;
    
    public DateTime ExpirationDate { get; set; }
    
    public int MaxTerminalCount { get; set; }
}
