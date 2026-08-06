using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Management;

public class CodeTemplate : FullAuditableEntity, IMustHaveBranch
{
    [Required]
    public ModuleType Module { get; set; }

    [Required]
    [MaxLength(20)]
    public string CodePrefix { get; set; } = string.Empty;

    public byte NumericLength { get; set; }

    public int StartNumber { get; set; }

    public DateFormat DateFormat { get; set; }

    [MaxLength(20)]
    public string CodeSuffix { get; set; } = string.Empty;

    public bool IsAutoCodeGenerationEnabled { get; set; }
    public bool IsUserInterventionAllowed { get; set; }
    public bool IsCompanyShortCodeUsed { get; set; }
    public bool IsDateBasedCodeGenerationEnabled { get; set; }
    public bool IsDateBasedCodeResetEnabled { get; set; }

    public long BranchId { get; set; }
}
