using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production;

public class GasValveListDto : BaseDto
{

    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public GasType? GasType { get; set; }
    public bool HasSafetyValve { get; set; }
    public int? OutletAngle { get; set; }
    public string? ShaftType { get; set; }
    public string? Description { get; set; }

    public string? SpecialCodeCode { get; set; }
    public string? SpecialCodeName { get; set; }


}
