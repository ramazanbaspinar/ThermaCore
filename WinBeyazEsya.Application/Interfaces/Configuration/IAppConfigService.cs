namespace WinBeyazEsya.Application.Interfaces.Configuration;

public interface IAppConfigService
{
    string GetLastLoginUser();
    void SetLastLoginUser(string username);
    string GetConnectionString();
    void SetConnectionString(string connectionString);
    long GetLastTenantId();
    void SetLastTenantId(long tenantId);
    long GetLastBranchId();
    void SetLastBranchId(long branchId);
    bool GetAskBranchAtStartup();
    void SetAskBranchAtStartup(bool ask);
    string GetLastSeenVersion();
    void SetLastSeenVersion(string version);
}

