using System;
using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

public class Terminal : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [MaxLength(100)]
    public string HardwareId { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

}

