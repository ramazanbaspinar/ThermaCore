using AutoMapper;
using WinBeyazEsya.Application.DTOs.Security;
using WinBeyazEsya.Domain.Entities.Security;

namespace WinBeyazEsya.Application.Mappings;

public class SecurityProfile : Profile
{
    public SecurityProfile()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<RolePermission, RolePermissionDto>().ReverseMap();
        CreateMap<UserPermission, UserPermissionDto>().ReverseMap();
    }
}

