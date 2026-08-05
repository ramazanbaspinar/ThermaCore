using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Production;

public class GasValveDto : BaseDto
{

    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public GasType? GasType { get; set; }
    public bool HasSafetyValve { get; set; }
    public int? OutletAngle { get; set; }
    public string? ShaftType { get; set; }
    public string? Description { get; set; }

    public long? SpecialCodeId { get; set; }
    public string? SpecialCodeCode { get; set; }
    public string? SpecialCodeName { get; set; }


}

