using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Production;

public class MaterialCost : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;

    public ModuleType MaterialType { get; set; }

    public long MaterialId { get; set; }

    public decimal Cost { get; set; }

    [Required]
    [MaxLength(5)]
    public string CurrencyCode { get; set; } = string.Empty;
}
