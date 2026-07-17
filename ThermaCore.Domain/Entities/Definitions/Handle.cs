using System;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Definitions;

public class Handle : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public HandleType? HandleType { get; set; }
    public MaterialType? MaterialType { get; set; }
    public string? Color { get; set; }
    public decimal? LengthMm { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    // Zırhlı Kural: Entity IsActive Unutulmazı
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }
}
