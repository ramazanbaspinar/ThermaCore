using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using FluentValidation;

namespace ThermaCore.Application.Services.Management;

public class SystemParameterManager : ISystemParameterService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<SystemParameter> _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<SystemParameterDto> _validator;

    public SystemParameterManager(
        IUnitOfWork unitOfWork, 
        IRepository<SystemParameter> repository, 
        IMapper mapper,
        IValidator<SystemParameterDto> validator)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public Task<SystemParameterDto> GetSystemParameterAsync()
    {
        var entity = _repository.Find(x => true).FirstOrDefault();
        if (entity == null)
        {
            return Task.FromResult(new SystemParameterDto { Id = 0 });
        }
        return Task.FromResult(_mapper.Map<SystemParameterDto>(entity));
    }

    public async Task SaveParameterAsync(SystemParameterDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var existing = _repository.Find(x => true).FirstOrDefault();
        
        if (existing == null)
        {
            // Insert
            dto.Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId();
            var entity = _mapper.Map<SystemParameter>(dto);
            _repository.Add(entity);
        }
        else
        {
            // Update
            dto.Id = existing.Id; // Prevent changing the PK of the tracked entity
            _mapper.Map(dto, existing);
            _repository.Update(existing);
        }
        
        _unitOfWork.SaveChanges();
    }
}
