namespace ThermaCore.Application.Interfaces.System;

public interface ICurrentTenantService
{
    string ConnectionString { get; set; }
    long TenantId { get; set; }
}
