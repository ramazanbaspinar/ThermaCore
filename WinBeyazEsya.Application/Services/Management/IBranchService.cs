using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Services.Management;

public interface IBranchService
{
    BranchDto GetById(long id);
    IEnumerable<BranchDto> GetAll();
    long Insert(BranchDto dto);
    void Update(BranchDto dto);
    void Delete(long id);
    IEnumerable<BranchDto> GetActiveBranches();
}

