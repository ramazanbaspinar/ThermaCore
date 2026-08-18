using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Management;

public class UserBranchDto : BaseDto
{
    public long UserId { get; set; }
    public long BranchId { get; set; }

    public bool IsDefault { get; set; }
}

