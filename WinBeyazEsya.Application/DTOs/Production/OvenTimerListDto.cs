using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production;

public class OvenTimerListDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;

    public int? MaxDurationMinutes { get; set; }
    public string? TimerType { get; set; }
    public int? CurrentAmper { get; set; }
    public int? Voltage { get; set; }
    public string? Description { get; set; }
    
    public string? SpecialCodeName { get; set; }
}

