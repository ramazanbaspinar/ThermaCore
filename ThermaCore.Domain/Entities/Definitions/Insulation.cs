using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Definitions;

public class Insulation : FullAuditableEntity
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

    public InsulationType? InsulationType { get; set; }

    public decimal? ThicknessMm { get; set; }

    public int? Density { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public virtual SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}
