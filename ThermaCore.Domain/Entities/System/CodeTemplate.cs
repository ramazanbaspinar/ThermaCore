using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.System;

public class CodeTemplate : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ModuleType Module { get; set; }
    
    [MaxLength(10)]
    public string CodePrefix { get; set; } = string.Empty;
    
    [MaxLength(10)]
    public string CodeSuffix { get; set; } = string.Empty;
    
    public int StartNumber { get; set; }
    public int NumericLength { get; set; }
    public DateFormat DateFormat { get; set; }
}
