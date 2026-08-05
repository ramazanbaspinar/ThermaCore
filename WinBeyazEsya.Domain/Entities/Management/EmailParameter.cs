using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

public class EmailParameter : AuditableEntity
{
    [MaxLength(200)]
    public string SmtpServer { get; set; } = string.Empty;
    
    public int Port { get; set; }
    
    [MaxLength(200)]
    public string SenderName { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string SenderEmail { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string Password { get; set; } = string.Empty;
    
    public bool EnableSsl { get; set; }
}

