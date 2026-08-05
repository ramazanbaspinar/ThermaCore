using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Production;

public class OvenMotor : FullAuditableEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string BaseUnit { get; set; } = null!;
    public MotorType? MotorType { get; set; }
    public int? PowerWatt { get; set; }
    public int? Voltage { get; set; }
    public int? Rpm { get; set; }
    public decimal? ShaftLengthMm { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // Relations
    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }
}

