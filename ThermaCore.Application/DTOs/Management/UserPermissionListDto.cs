using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Management;

public class UserPermissionListDto : BaseHareketDto
{
    public long UserId { get; set; }
    public ModuleType Module { get; set; }
    
    public byte CanView { get; set; }
    public byte CanAdd { get; set; }
    public byte CanEdit { get; set; }
    public byte CanDelete { get; set; }
}
