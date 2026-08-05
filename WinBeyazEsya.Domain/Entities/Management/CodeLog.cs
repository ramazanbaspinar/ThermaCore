using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Management;

public class CodeLog : Entity
{
    [Required]
    public ModuleType Module { get; set; }

    [StringLength(100)]
    public string CompanyCode { get; set; } = string.Empty;

    [StringLength(100)]
    public string DateKey { get; set; } = string.Empty;

    public int LastCodeValue { get; set; }
    
    public long? BranchId { get; set; }
}

