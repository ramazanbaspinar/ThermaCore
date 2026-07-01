using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Common;

public class ItemBarcode : FullAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string BarcodeValue { get; set; } = string.Empty;

    public string? BarcodeType { get; set; }

    public long RecordId { get; set; }

    public ModuleType ModuleType { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsPrimary { get; set; } = false;

    [MaxLength(20)]
    public string? Unit { get; set; }

    public decimal QuantityPerUnit { get; set; } = 1;

    public decimal WeightPerUnit { get; set; }
}
