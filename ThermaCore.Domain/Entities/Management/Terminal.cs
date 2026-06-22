using System;
using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Management;

public class Terminal : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [MaxLength(100)]
    public string DeviceName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string MacAddress { get; set; } = string.Empty;

    [MaxLength(50)]
    public string IpAddress { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(200)]
    public string HardwareFingerprint { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string LicenseKey { get; set; } = string.Empty;

    public DateTime? LastLoginDate { get; set; }
}
