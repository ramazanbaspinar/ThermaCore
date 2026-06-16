namespace ThermaCore.Application.DTOs.Base;

public abstract class BaseDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
