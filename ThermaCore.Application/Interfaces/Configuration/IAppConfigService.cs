namespace ThermaCore.Application.Interfaces.Configuration;

public interface IAppConfigService
{
    string GetLastLoginUser();
    void SetLastLoginUser(string username);
    string GetConnectionString();
    void SetConnectionString(string connectionString);
    long GetLastTenantId();
    void SetLastTenantId(long tenantId);
}
