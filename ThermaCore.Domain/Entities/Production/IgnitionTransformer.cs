using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Production;

public class IgnitionTransformer : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string BaseUnit { get; set; } = string.Empty;

    public int? OutputCount { get; set; }

    [MaxLength(50)]
    public string? Voltage { get; set; }

    [MaxLength(50)]
    public string? Frequency { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public virtual ThermaCore.Domain.Entities.Common.SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}
