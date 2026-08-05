using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management;

public class Branch : FullAuditableEntity
{
    public long TenantDatabaseId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string BranchName { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    public bool IsActive { get; set; } = true;
}

