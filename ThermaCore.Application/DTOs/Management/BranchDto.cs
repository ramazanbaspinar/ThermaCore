using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Management;

public class BranchDto : BaseDto
{
    public long TenantDatabaseId { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public string? Description { get; set; }
}
