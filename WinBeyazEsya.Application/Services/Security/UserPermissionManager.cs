using AutoMapper;
using WinBeyazEsya.Application.DTOs.Security;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Domain.Entities.Security;

namespace WinBeyazEsya.Application.Services.Security;

public class UserPermissionManager : IUserPermissionService
{
    private readonly IMasterRepository<UserPermission> _userPermissionRepository;
    private readonly IMasterUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UserPermissionManager(
        IMasterRepository<UserPermission> userPermissionRepository,
        IMasterUnitOfWork uow,
        IMapper mapper)
    {
        _userPermissionRepository = userPermissionRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public IEnumerable<UserPermissionDto> GetUserPermissions(long userId)
    {
        var permissions = _userPermissionRepository.Find(x => x.UserId == userId).ToList();
        var dtos = _mapper.Map<IEnumerable<UserPermissionDto>>(permissions).ToList();

        foreach (var existingPerm in dtos)
        {
            // Güvenlik Kuralı: NullReferenceException önlemi
            if (string.IsNullOrWhiteSpace(existingPerm.SpecialPermissions))
                existingPerm.SpecialPermissions = "{}";
        }

        return dtos;
    }

    private string GetEnumDescription(Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo != null)
        {
            var attributes = (global::System.ComponentModel.DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(global::System.ComponentModel.DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
        }
        return value.ToString();
    }

    public void SaveUserPermissions(long userId, List<UserPermissionDto> permissions)
    {
        // First delete all existing permissions for this user
        var existingPermissions = _userPermissionRepository.Find(x => x.UserId == userId).ToList();
        foreach (var p in existingPermissions)
        {
            _userPermissionRepository.Remove(p);
        }

        // Then add the new ones
        if (permissions != null && permissions.Any())
        {
            foreach (var p in permissions)
            {
                var entity = new UserPermission
                {
                    Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                    UserId = userId,
                    ModuleId = p.ModuleId,
                    ParentId = p.ParentId,
                    ModuleName = p.ModuleName,
                    CanRead = p.CanRead,
                    CanCreate = p.CanCreate,
                    CanUpdate = p.CanUpdate,
                    CanDelete = p.CanDelete,
                    SpecialPermissions = string.IsNullOrWhiteSpace(p.SpecialPermissions) ? "{}" : p.SpecialPermissions
                };
                _userPermissionRepository.Add(entity);
            }
        }

        _uow.SaveChanges();
    }

    public void DeleteUserPermissions(long userId)
    {
        var existingPermissions = _userPermissionRepository.Find(x => x.UserId == userId).ToList();
        foreach (var p in existingPermissions)
        {
            _userPermissionRepository.Remove(p);
        }
        _uow.SaveChanges();
    }
}

