using System.Threading.Tasks;

namespace WinBeyazEsya.Application.Interfaces.System;

public interface ITenantDatabaseService
{
    Task CreateDatabaseAsync(string connectionString);
    Task CreateMasterDatabaseAsync(string connectionString);
    Task<bool> CheckDatabaseExistsAsync(string masterConnectionString, string databaseName);
}

