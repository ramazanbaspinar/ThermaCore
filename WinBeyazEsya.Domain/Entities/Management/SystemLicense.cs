using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

public class SystemLicense : AuditableEntity
{
    [MaxLength(100)]
    public string ServerHardwareId { get; set; } = string.Empty;

    [MaxLength(500)]
    public string LicenseKey { get; set; } = string.Empty;

    public DateTime ExpirationDate { get; set; }

    public int MaxTerminalCount { get; set; }
}

