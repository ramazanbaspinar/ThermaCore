using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Definitions;

public class Unit : FullAuditableEntity
{
    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [MaxLength(500)]
    public string? Description { get; set; }
}
