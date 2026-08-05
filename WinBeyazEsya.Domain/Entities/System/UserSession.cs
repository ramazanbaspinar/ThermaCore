using System;
using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.System;

public class UserSession : AuditableEntity
{
    public long UserId { get; set; }
    public DateTime LoginTime { get; set; }
    public DateTime? LogoutTime { get; set; }
    
    [MaxLength(50)]
    public string IpAddress { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string ComputerName { get; set; } = string.Empty;
    
    public SessionStatus Status { get; set; }
}

