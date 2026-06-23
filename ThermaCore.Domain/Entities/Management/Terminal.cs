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
    public string EthernetMacAddress { get; set; } = string.Empty;

    [MaxLength(50)]
    public string WifiMacAddress { get; set; } = string.Empty;

    [MaxLength(50)]
    public string VpnMacAddress { get; set; } = string.Empty;

    [MaxLength(50)]
    public string IpAddress { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

}
