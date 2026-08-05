using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Management;

public class CodeLogDto : BaseDto
{
    public ModuleType Module { get; set; }
    public string CompanyCode { get; set; } = string.Empty;
    public string DateKey { get; set; } = string.Empty;
    public int LastCodeValue { get; set; }
    public long? BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;
}

