using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Management;

public class CodeTemplate : FullAuditableEntity
{
    [Required]
    public ModuleType Module { get; set; }

    [Required]
    [StringLength(100)]
    public string CodePrefix { get; set; } = string.Empty;

    [Required]
    public byte NumericLength { get; set; }

    [Required]
    public int StartNumber { get; set; }

    [Required]
    public DateFormat DateFormat { get; set; }

    [StringLength(100)]
    public string CodeSuffix { get; set; } = string.Empty;

    public bool IsAutoCodeGenerationEnabled { get; set; }
    public bool IsUserInterventionAllowed { get; set; }
    public bool IsCompanyShortCodeUsed { get; set; }
    public bool IsDateBasedCodeGenerationEnabled { get; set; }
    public bool IsDateBasedCodeResetEnabled { get; set; }
}

