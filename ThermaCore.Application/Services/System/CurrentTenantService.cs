using ThermaCore.Application.Interfaces.System;

namespace ThermaCore.Application.Services.System;

public class CurrentTenantService : ICurrentTenantService
{
    public string ConnectionString { get; set; } = string.Empty;
    public long TenantId { get; set; }
}
