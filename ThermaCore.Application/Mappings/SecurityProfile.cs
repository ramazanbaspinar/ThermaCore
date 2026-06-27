using AutoMapper;
using ThermaCore.Application.DTOs.Security;
using ThermaCore.Domain.Entities.Security;

namespace ThermaCore.Application.Mappings;

public class SecurityProfile : Profile
{
    public SecurityProfile()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<RolePermission, RolePermissionDto>().ReverseMap();
        CreateMap<UserPermission, UserPermissionDto>().ReverseMap();
    }
}
