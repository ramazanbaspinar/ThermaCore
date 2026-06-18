using AutoMapper;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Mappings;

public class ManagementProfile : Profile
{
    public ManagementProfile()
    {
        CreateMap<UserRole, UserRoleDto>().ReverseMap();
        CreateMap<UserRole, UserRoleListDto>();

        CreateMap<User, UserDto>()
            .ForMember(x => x.RoleName, opt => opt.MapFrom(src => src.UserRole.RoleName))
            .ReverseMap();

        CreateMap<User, UserListDto>()
            .ForMember(x => x.RoleName, opt => opt.MapFrom(src => src.UserRole.RoleName));

        CreateMap<ModulePermission, ModulePermissionListDto>().ReverseMap();
        CreateMap<UserPermission, UserPermissionListDto>().ReverseMap();
        
        CreateMap<Terminal, TerminalDto>().ReverseMap();
        CreateMap<Terminal, TerminalListDto>();

        CreateMap<TenantDatabase, TenantDatabaseDto>().ReverseMap();
        CreateMap<TenantDatabase, TenantDatabaseListDto>();

        CreateMap<Branch, BranchDto>().ReverseMap();
    }
}
