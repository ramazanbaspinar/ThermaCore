using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Services.Management;

public class UserManager : BaseManager<UserDto, UserDto, User>, IUserService
{
    public UserManager(
        IMapper mapper, 
        IRepository<User> repository, 
        IUnitOfWork unitOfWork, 
        IValidator<UserDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override long Insert(UserDto dto)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(dto);
        }

        var entity = _mapper.Map<User>(dto);

        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            PasswordHasher.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
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

        _repository.Update(entity);
        _unitOfWork.SaveChanges();

    }

    public IEnumerable<UserListDto> GetActiveUsers()
    {
        var entities = _repository.Find(x => !x.IsDeleted && x.IsActive).ToList();
        return _mapper.Map<IEnumerable<UserListDto>>(entities);
    }

    public UserDto UserLogin(string username, string password)
    {
        var user = _repository.Find(x => x.Code == username && !x.IsDeleted && x.IsActive).FirstOrDefault();
        if (user == null) throw new Exception("Kullanıcı adı veya şifre hatalı.");

        if (!PasswordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new Exception("Kullanıcı adı veya şifre hatalı.");

        return _mapper.Map<UserDto>(user);
    }
}
