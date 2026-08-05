using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Services.Management;

public class MaliyetParametreManager : IMaliyetParametreService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<MaliyetParametre> _repository;
    private readonly IMapper _mapper;

    public MaliyetParametreManager(
        IUnitOfWork unitOfWork, 
        IRepository<MaliyetParametre> repository, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
    }

    public Task<MaliyetParametreDto> GetMaliyetParametreAsync()
    {
        var entity = _repository.Find(x => true).FirstOrDefault();
        if (entity == null)
        {
            return Task.FromResult(new MaliyetParametreDto { Id = 0 });
        }
        return Task.FromResult(_mapper.Map<MaliyetParametreDto>(entity));
    }

    public Task SaveParametreAsync(MaliyetParametreDto dto)
    {
        var existing = _repository.Find(x => true).FirstOrDefault();
        
        if (existing == null)
        {
            // Insert
            dto.Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId();
            var entity = _mapper.Map<MaliyetParametre>(dto);
            _repository.Add(entity);
        }
        else
        {
            // Update
            dto.Id = existing.Id; // Prevent changing the PK
            _mapper.Map(dto, existing);
            _repository.Update(existing);
        }
        
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}

