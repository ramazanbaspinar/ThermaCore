using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Domain.Entities.Production;

public class SheetMetal : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public long QualityStandardId { get; set; }
    public virtual QualityStandard QualityStandard { get; set; } = null!;

    public long SurfaceTypeId { get; set; }
    public virtual SurfaceType SurfaceType { get; set; } = null!;

    public long UnitId { get; set; }
    public virtual Unit Unit { get; set; } = null!;

    public decimal Thickness { get; set; }

    public decimal Density { get; set; } = 7.85m;


    [MaxLength(500)]
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public virtual ThermaCore.Domain.Entities.Common.SpecialCode? SpecialCode { get; set; }

    public long? GroupCodeId { get; set; }
    public virtual ThermaCore.Domain.Entities.Common.SpecialCode? GroupCode { get; set; }

    public bool IsActive { get; set; } = true;
}
