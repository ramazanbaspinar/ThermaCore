using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Common;

public class ItemBarcode : FullAuditableEntity, IMustHaveBranch
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

    public long BranchId { get; set; }
}

