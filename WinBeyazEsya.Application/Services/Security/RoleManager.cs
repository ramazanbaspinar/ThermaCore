using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Security;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Security;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Services.Security;

public class RoleManager : BaseMasterManager<RoleDto, RoleDto, Role>, IRoleService
{
    private readonly IMasterRepository<RolePermission> _permissionRepository;

    public RoleManager(
        IMapper mapper,
        IMasterRepository<Role> repository,
        IMasterRepository<RolePermission> permissionRepository,
        IMasterUnitOfWork unitOfWork,
        IValidator<RoleDto>? validator = null)
        : base(mapper, repository, unitOfWork, validator)
    {
        _permissionRepository = permissionRepository;
    }

    public IEnumerable<RoleDto> GetActiveRoles()
    {
        var entities = _repository.Find(x => !x.IsDeleted && x.IsActive).ToList();
        return _mapper.Map<IEnumerable<RoleDto>>(entities);
    }

    public IEnumerable<RolePermissionDto> GetRolePermissions(long roleId)
    {
        var permissions = _permissionRepository.Find(x => x.RoleId == roleId).ToList();
        var dtos = _mapper.Map<IEnumerable<RolePermissionDto>>(permissions).ToList();
        var emptyPermissions = GetEmptyPermissions().ToList();

        var result = new List<RolePermissionDto>();

        foreach (var emptyPerm in emptyPermissions)
        {
            var existingPerm = dtos.FirstOrDefault(x => x.ModuleId == emptyPerm.ModuleId);
            if (existingPerm != null)
            {
                // Mevcut veriyi al, ancak ParentId ve ModuleName gibi meta verileri Enum'dan güncelleyerek al
                existingPerm.ParentId = emptyPerm.ParentId;
                existingPerm.ModuleName = emptyPerm.ModuleName;
                result.Add(existingPerm);
            }
            else
            {
                result.Add(emptyPerm);
            }
        }

        return result;
    }

    public IEnumerable<RolePermissionDto> GetEmptyPermissions()
    {
        var list = new List<RolePermissionDto>();
        foreach (ModuleType module in Enum.GetValues(typeof(ModuleType)))
        {
            list.Add(new RolePermissionDto
            {
                ModuleId = (int)module,
                ParentId = WinBeyazEsya.Domain.Helpers.EnumFunctions.GetParentModule(module) != null ? (int)WinBeyazEsya.Domain.Helpers.EnumFunctions.GetParentModule(module)! : 0,
                ModuleName = GetEnumDescription(module),
                CanRead = false,
                CanCreate = false,
                CanUpdate = false,
                CanDelete = false,
                IsActive = true
            });
        }
        return list;
    }

    public long SaveRoleWithPermissions(RoleDto roleDto, List<RolePermissionDto> permissionsDto)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(roleDto);
        }

        Role entity = _repository.GetById(roleDto.Id);
        if (entity == null) // Insert (Entity doesn't exist in DB)
        {
            entity = _mapper.Map<Role>(roleDto);
            _repository.Add(entity);
            // No need to SaveChanges yet, it will be saved with permissions below
        }
        else // Update
        {
            _mapper.Map(roleDto, entity);
            _repository.Update(entity);
        }

        // Handle permissions
        var existingPermissions = _permissionRepository.Find(x => x.RoleId == entity.Id).ToList();

        // Remove old permissions
        foreach (var p in existingPermissions)
        {
            _permissionRepository.Remove(p);
        }

        // Add new permissions
        foreach (var pDto in permissionsDto)
        {
            var pEntity = _mapper.Map<RolePermission>(pDto);
            pEntity.Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(); // Assign unique ID FIRST to prevent EF tracking collisions
            pEntity.RoleId = entity.Id;
            pEntity.Role = entity; // Now EF Core tracks it with its unique ID
            _permissionRepository.Add(pEntity);
        }

        _unitOfWork.SaveChanges();
        return entity.Id;
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
}

