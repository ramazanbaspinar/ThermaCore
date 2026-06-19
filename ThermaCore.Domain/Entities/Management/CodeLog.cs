using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Management;

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
