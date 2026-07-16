using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Definitions;

public class Gasket : FullAuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    
    public GasketMaterialType? MaterialType { get; set; }
    public int? HeatResistance { get; set; }
    public decimal? LengthMm { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}
