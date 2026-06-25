using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Definitions;

public class ItemCategory : FullAuditableEntity
{
    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public long? ParentId { get; set; }

    [ForeignKey(nameof(ParentId))]
    public ItemCategory? Parent { get; set; }

    public bool IsActive { get; set; } = true;

    [MaxLength(500)]
    public string? Description { get; set; }
}
