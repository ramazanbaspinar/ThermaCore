using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Production;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Services.Production;

public class MaterialCostManager : BaseManager<MaterialCostListDto, MaterialCostDto, MaterialCost>, IMaterialCostService
{
    public MaterialCostManager(
        IMapper mapper,
        IRepository<MaterialCost> repository,
        IUnitOfWork unitOfWork,
        IValidator<MaterialCostDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<MaterialCostListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<MaterialCostListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }

    public IEnumerable<MaterialCostListDto> GetAllByMaterialType(ModuleType type)
    {
        var query = _repository.Find(x => x.MaterialType == type);
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<MaterialCostListDto>(query, _mapper.ConfigurationProvider).ToList();
    }

    public IEnumerable<MaterialCostListDto> GetAllByMaterialIds(IEnumerable<long> materialIds)
    {
        var query = _repository.Find(x => materialIds.Contains(x.MaterialId));
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<MaterialCostListDto>(query, _mapper.ConfigurationProvider).ToList();
    }

    public override void Delete(long id)
    {
        try
        {
            base.Delete(id);
        }
        catch (global::System.Exception ex)
        {
            if (ex is global::System.InvalidOperationException && ex.Message.Contains("Güvenlik Kısıtlaması"))
            {
                throw new FluentValidation.ValidationException("Seçilen kaydın işlem görmüş hareketi var, silinemez!");
            }
            
            if (ex.InnerException != null && (ex.InnerException.Message.Contains("REFERENCE constraint") || ex.InnerException.Message.Contains("FOREIGN KEY")))
            {
                throw new FluentValidation.ValidationException("Seçilen kaydın işlem görmüş hareketi var, silinemez!");
            }
            throw; // Re-throw if it's some other exception
        }
    }
}

