using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IPackagingAndPrintingGroupService : IBaseService
{
    PackagingAndPrintingGroupDto GetById(long id);
    IEnumerable<PackagingAndPrintingGroupListDto> GetAll();
    long Insert(PackagingAndPrintingGroupDto dto);
    void Update(PackagingAndPrintingGroupDto dto);
    void Delete(long id);
}

