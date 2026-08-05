using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Interfaces.System;

public interface ITenantDatabaseCrudService
{
    TenantDatabaseDto GetById(long id);
    IEnumerable<TenantDatabaseDto> GetAll();
    long Insert(TenantDatabaseDto dto);
    void Update(TenantDatabaseDto dto);
    void Delete(long id);
    IEnumerable<TenantDatabaseDto> GetActiveTenants();
}

