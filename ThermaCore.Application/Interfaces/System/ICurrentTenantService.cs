namespace ThermaCore.Application.Interfaces.System;

public interface ICurrentTenantService
{
    string ConnectionString { get; set; }
    long UserId { get; set; }
    long TenantId { get; set; }
    string TenantName { get; set; }
    long BranchId { get; set; }
    string BranchName { get; set; }
}
