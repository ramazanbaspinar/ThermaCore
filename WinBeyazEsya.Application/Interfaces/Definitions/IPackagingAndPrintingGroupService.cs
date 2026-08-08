using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IPackagingAndPrintingGroupService
{
    PackagingAndPrintingGroupDto GetById(long id);
    IEnumerable<PackagingAndPrintingGroupListDto> GetAll();
    long Insert(PackagingAndPrintingGroupDto dto);
    void Update(PackagingAndPrintingGroupDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
