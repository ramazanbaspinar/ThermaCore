using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Management;

public class CodeTemplateDto : BaseDto
{
    public ModuleType Module { get; set; }
    public string CodePrefix { get; set; } = string.Empty;
    public byte NumericLength { get; set; }
    public int StartNumber { get; set; }
    public DateFormat DateFormat { get; set; }
    public string CodeSuffix { get; set; } = string.Empty;
    public bool IsAutoCodeGenerationEnabled { get; set; }
    public bool IsUserInterventionAllowed { get; set; }
    public bool IsCompanyShortCodeUsed { get; set; }
    public bool IsDateBasedCodeGenerationEnabled { get; set; }
    public bool IsDateBasedCodeResetEnabled { get; set; }
    public long BranchId { get; set; }
}

