using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Production;

public class Boya : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string BaseUnit { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? ColorCode { get; set; }

    public int? HeatResistance { get; set; }

    public int? DryingTimeMinutes { get; set; }

    public int? ShelfLifeMonths { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public virtual WinBeyazEsya.Domain.Entities.Common.SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}

