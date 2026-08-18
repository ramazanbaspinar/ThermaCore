using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Management;

public class UserTenantDto : BaseDto
{
    public long UserId { get; set; }
    public long TenantDatabaseId { get; set; }

    public bool IsDefault { get; set; }
}

