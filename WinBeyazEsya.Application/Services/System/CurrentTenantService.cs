using WinBeyazEsya.Application.Interfaces.System;

namespace WinBeyazEsya.Application.Services.System;

public class CurrentTenantService : ICurrentTenantService
{
    public string ConnectionString { get; set; } = string.Empty;
    public long UserId { get; set; } = 0;
    public long TenantId { get; set; } = 0;
    public string TenantName { get; set; } = string.Empty;
    public long BranchId { get; set; } = 0;
    public string BranchName { get; set; } = string.Empty;
}

