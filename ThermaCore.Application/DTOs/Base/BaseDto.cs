namespace ThermaCore.Application.DTOs.Base;

public abstract class BaseDto
{
    public long Id { get; set; }
    public string Kod { get; set; } = string.Empty;
    public bool Durum { get; set; } = true;
}
