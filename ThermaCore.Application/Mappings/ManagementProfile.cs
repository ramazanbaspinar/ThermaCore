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
            .ForMember(x => x.RoleName, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.UserRole, opt => opt.Ignore())
            .ForMember(x => x.UserTenants, opt => opt.Ignore())
            .ForMember(x => x.UserBranches, opt => opt.Ignore());

        CreateMap<User, UserListDto>()
            .ForMember(x => x.RoleName, opt => opt.Ignore());

        CreateMap<ModulePermission, ModulePermissionListDto>().ReverseMap();
        CreateMap<UserPermission, UserPermissionListDto>().ReverseMap();
        CreateMap<UserTenant, UserTenantDto>().ReverseMap();
        CreateMap<UserBranch, UserBranchDto>().ReverseMap();
        
        CreateMap<Terminal, TerminalDto>().ReverseMap();
        CreateMap<Terminal, TerminalListDto>();

        CreateMap<TenantDatabase, TenantDatabaseDto>().ReverseMap();
        CreateMap<TenantDatabase, TenantDatabaseListDto>();

        CreateMap<Branch, BranchDto>().ReverseMap();
    }
}
