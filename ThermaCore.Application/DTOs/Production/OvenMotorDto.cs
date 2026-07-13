using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production;

public class OvenMotorDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public MotorType? MotorType { get; set; }
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public int? Rpm { get; set; }
    public decimal? ShaftLengthMm { get; set; }
    public string? Description { get; set; }

    // Relations
    public long? SpecialCodeId { get; set; }
}

public class OvenMotorListDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public string? MotorTypeName { get; set; }
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public int? Rpm { get; set; }
    public decimal? ShaftLengthMm { get; set; }
    public string? Description { get; set; }
    public string? SpecialCodeName { get; set; }
}
