using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Common;

public class ItemBarcodeListDto : BaseDto
{
    public string BarcodeValue { get; set; } = string.Empty;
    public string? BarcodeType { get; set; }
    public long RecordId { get; set; }
    public ModuleType ModuleType { get; set; }
    public string? Description { get; set; }
    public bool IsPrimary { get; set; } = false;

    public string? Unit { get; set; }
    public decimal QuantityPerUnit { get; set; } = 1;
    public decimal WeightPerUnit { get; set; }
}

