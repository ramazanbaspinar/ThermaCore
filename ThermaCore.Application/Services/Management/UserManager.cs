using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Services.Management;

public class UserManager : BaseMasterManager<UserDto, UserDto, User>, IUserService
{
    private readonly IRoleService _roleService;
    private readonly ITerminalService _terminalService;
    private readonly IMasterRepository<UserTenant> _userTenantRepository;
    private readonly IMasterRepository<UserBranch> _userBranchRepository;

    public UserManager(
        IMapper mapper, 
        IMasterRepository<User> repository, 
        IMasterUnitOfWork unitOfWork, 
        IRoleService roleService,
        ITerminalService terminalService,
        IMasterRepository<UserTenant> userTenantRepository,
        IMasterRepository<UserBranch> userBranchRepository,
        IValidator<UserDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
        _roleService = roleService;
        _terminalService = terminalService;
        _userTenantRepository = userTenantRepository;
        _userBranchRepository = userBranchRepository;
    }

    public override long Insert(UserDto dto)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(dto);
        }

        var entity = _mapper.Map<User>(dto);

        // Manually map collections because they are ignored in AutoMapper to avoid tracking issues on update
        if (dto.UserTenants != null && dto.UserTenants.Any())
        {
            foreach (var tenantDto in dto.UserTenants)
            {
                entity.UserTenants.Add(new UserTenant { 
                    Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                    TenantDatabaseId = tenantDto.TenantDatabaseId 
                });
            }
        }

        if (dto.UserBranches != null && dto.UserBranches.Any())
        {
            foreach (var branchDto in dto.UserBranches)
            {
                entity.UserBranches.Add(new UserBranch { 
                    Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                    BranchId = branchDto.BranchId 
                });
            }
        }

        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            PasswordHasher.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
        }
        else
        {
            var failure = new FluentValidation.Results.ValidationFailure("Password", "Yeni kullanıcı oluşturulurken şifre boş bırakılamaz.");
            throw new FluentValidation.ValidationException(new[] { failure });
        }

        _repository.Add(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public override void Update(UserDto dto)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(dto);
        }

        var entity = _repository.GetById(dto.Id);
        if (entity == null) throw new Exception("User not found.");

        // Keep old hash and salt
        byte[] oldHash = entity.PasswordHash;
        byte[] oldSalt = entity.PasswordSalt;

        _mapper.Map(dto, entity);

        // If user entered a new password, hash it and update. Otherwise, keep the old one.
        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            PasswordHasher.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
        }
        else
        {
            entity.PasswordHash = oldHash;
            entity.PasswordSalt = oldSalt;
        }

        // Remove old relationships
        var existingTenants = _userTenantRepository.Find(x => x.UserId == entity.Id).ToList();
        foreach(var t in existingTenants)
        {
            _userTenantRepository.Remove(t);
        }

        var existingBranches = _userBranchRepository.Find(x => x.UserId == entity.Id).ToList();
        foreach(var b in existingBranches)
        {
            _userBranchRepository.Remove(b);
        }

        // Add new relationships
        foreach (var tenantDto in dto.UserTenants)
        {
            _userTenantRepository.Add(new UserTenant 
            { 
                Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                TenantDatabaseId = tenantDto.TenantDatabaseId, 
                UserId = entity.Id 
            });
        }

        foreach (var branchDto in dto.UserBranches)
        {
            _userBranchRepository.Add(new UserBranch 
            { 
                Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                BranchId = branchDto.BranchId, 
                UserId = entity.Id 
            });
        }

        _repository.Update(entity);
        _unitOfWork.SaveChanges();

    }

    public override IEnumerable<UserDto> GetAll()
    {
        var dtos = base.GetAll().ToList();
        MapRolesInMemory(dtos);
        return dtos;
    }

    public override UserDto GetById(long id)
    {
        var dto = base.GetById(id);
        if (dto != null)
        {
            if (dto.UserRoleId > 0)
            {
                var role = _roleService.GetById(dto.UserRoleId);
                if (role != null) dto.RoleName = role.RoleName;
            }

            var tenants = _userTenantRepository.Find(x => x.UserId == id && !x.IsDeleted).ToList();
            dto.UserTenants = _mapper.Map<List<UserTenantDto>>(tenants);

            var branches = _userBranchRepository.Find(x => x.UserId == id && !x.IsDeleted).ToList();
            dto.UserBranches = _mapper.Map<List<UserBranchDto>>(branches);
        }
        return dto!;
    }

    public IEnumerable<UserListDto> GetActiveUsers()
    {
        var entities = _repository.Find(x => !x.IsDeleted && x.IsActive).ToList();
        var dtos = _mapper.Map<IEnumerable<UserListDto>>(entities).ToList();
        
        var rolesDict = _roleService.GetActiveRoles().ToDictionary(x => x.Id, x => x.RoleName);
        foreach (var dto in dtos)
        {
            if (rolesDict.TryGetValue(dto.UserRoleId, out var roleName))
            {
                dto.RoleName = roleName;
            }
        }
        
        return dtos;
    }

    private void MapRolesInMemory(List<UserDto> dtos)
    {
        if (!dtos.Any()) return;
        
        // Fetch all roles instead of active only, in case old users have inactive roles
        var rolesDict = _roleService.GetAll().ToDictionary(x => x.Id, x => x.RoleName);
        foreach (var dto in dtos)
        {
            if (rolesDict.TryGetValue(dto.UserRoleId, out var roleName))
            {
                dto.RoleName = roleName;
            }
        }
    }

    public UserDto UserLogin(string username, string password)
    {
        var user = _repository.Find(x => x.Code == username && !x.IsDeleted && x.IsActive).FirstOrDefault();
        if (user == null) throw new Exception("Kullanıcı adı veya şifre hatalı.");

        if (!PasswordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new Exception("Kullanıcı adı veya şifre hatalı.");

        // MAC ADDRESS SECURITY SHIELD
        var macAddress = NetworkHelper.GetMacAddress();
        var terminal = _terminalService.GetTerminalByMacAddress(macAddress);
        if (terminal == null || !terminal.IsActive)
        {
            throw new Exception($"Güvenlik İhlali: Bu cihaz (MAC: {macAddress}) sisteme kayıtlı değil veya aktif edilmemiş. Giriş reddedildi.");
        }

        return _mapper.Map<UserDto>(user);
    }
}
