using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Management;

public class ModulePermissionListDto : BaseHareketDto
{
    public long UserRoleId { get; set; }
    public ModuleType Module { get; set; }
    
    public byte CanView { get; set; }
    public byte CanAdd { get; set; }
    public byte CanEdit { get; set; }
    public byte CanDelete { get; set; }
}
