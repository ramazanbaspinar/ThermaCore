using AutoMapper;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Mappings;

public class ManagementProfile : Profile
{
    public ManagementProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : string.Empty))
            .ReverseMap()
            .ForMember(x => x.Role, opt => opt.Ignore())
            .ForMember(x => x.UserTenants, opt => opt.Ignore())
            .ForMember(x => x.UserBranches, opt => opt.Ignore());

        CreateMap<User, UserListDto>()
            .ForMember(x => x.RoleName, opt => opt.Ignore());

        CreateMap<UserTenant, UserTenantDto>().ReverseMap();
        CreateMap<UserBranch, UserBranchDto>().ReverseMap();
        
        CreateMap<Terminal, TerminalDto>().ReverseMap();
        CreateMap<Terminal, TerminalListDto>();

        CreateMap<TenantDatabase, TenantDatabaseDto>().ReverseMap();
        CreateMap<TenantDatabase, TenantDatabaseListDto>();

        CreateMap<Branch, BranchDto>().ReverseMap();
    }
}

