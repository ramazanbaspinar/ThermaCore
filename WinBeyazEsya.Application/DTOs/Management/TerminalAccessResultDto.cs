namespace WinBeyazEsya.Application.DTOs.Management;

public class TerminalAccessResultDto
{
    public bool HasAccess { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}

