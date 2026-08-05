using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Security;

public class RoleDto : BaseDto
{
    public string RoleName { get; set; } = null!;
    public string? Description { get; set; }
}

