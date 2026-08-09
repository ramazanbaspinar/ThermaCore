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
    private readonly IRepository<SystemParameter> _systemRepo;
    private readonly IMapper _mapper;

    public MaliyetParametreManager(
        IUnitOfWork unitOfWork, 
        IRepository<MaliyetParametre> repository, 
        IRepository<SystemParameter> systemRepo,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _systemRepo = systemRepo;
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
            dto.BranchId = existing.BranchId; // KORUMA: Şube ID'sinin sıfırlanmasını engelle
            _mapper.Map(dto, existing);
            _repository.Update(existing);
        }
        
        // Sistem Parametreleri (Genel Parametreler) Senkronizasyonu
        // Maliyet ekranından Fire Oranı değiştirildiğinde, genel parametrelerdeki varsayılan fire oranı da eşzamanlı değişecek.
        var systemParam = _systemRepo.Find(x => true).FirstOrDefault();
        if (systemParam != null)
        {
            systemParam.DefaultWastageRate = dto.WastageRate;
            _systemRepo.Update(systemParam);
        }

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}

