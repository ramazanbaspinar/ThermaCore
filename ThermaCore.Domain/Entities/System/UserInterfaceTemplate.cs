using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.System;

public class UserInterfaceTemplate : AuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public long UserId { get; set; }
    
    [MaxLength(100)]
    public string FormName { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string ControlName { get; set; } = string.Empty;
    
    public string XmlData { get; set; } = string.Empty;
}
