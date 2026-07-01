using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Common;

public class ItemBarcodeDto : BaseDto
{
    public string BarcodeValue { get; set; } = string.Empty;
    public string? BarcodeType { get; set; }
    public long RecordId { get; set; }
    public ModuleType ModuleType { get; set; }
    public string? Description { get; set; }
    public bool IsPrimary { get; set; }
}
