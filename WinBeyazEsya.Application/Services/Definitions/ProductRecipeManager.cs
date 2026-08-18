using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Application.Services.Definitions;

public class ProductRecipeManager : BaseManager<ProductRecipeListDto, ProductRecipeDto, ProductRecipe>, IProductRecipeService
{
    private readonly IRepository<ProductRecipeLine> _lineRepository;
    private readonly IServiceProvider _serviceProvider;

    public ProductRecipeManager(
        IMapper mapper,
        IRepository<ProductRecipe> repository,
        IRepository<ProductRecipeLine> lineRepository,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider,
        IValidator<ProductRecipeDto>? validator = null)
        : base(mapper, repository, unitOfWork, validator)
    {
        _lineRepository = lineRepository;
        _serviceProvider = serviceProvider;
    }

    public override IEnumerable<ProductRecipeListDto> GetAll()
    {
        return _repository.GetAll().ProjectTo<ProductRecipeListDto>(_mapper.ConfigurationProvider).ToList();
    }

    public override long Insert(ProductRecipeDto dto)
    {
        _validator?.ValidateAndThrow(dto);

        if (dto.Id == 0) dto.Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId();

        foreach (var line in dto.Lines)
        {
            if (line.Id == 0) line.Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId();
        }

        var entity = _mapper.Map<ProductRecipe>(dto);

        if (dto.Lines != null && dto.Lines.Any())
        {
            entity.Lines = _mapper.Map<List<ProductRecipeLine>>(dto.Lines);
            foreach (var line in entity.Lines)
            {
                line.ProductRecipeId = entity.Id;
            }
        }

        _repository.Add(entity);
        _unitOfWork.SaveChanges(); // Transaction commits both master and details (because of EF Core nav property mapping)

        return entity.Id;
    }

    public override void Update(ProductRecipeDto dto)
    {
        _validator?.ValidateAndThrow(dto);

        var entity = _repository.Find(x => x.Id == dto.Id).FirstOrDefault();
        if (entity != null)
        {
            _mapper.Map(dto, entity);

            var existingLines = _lineRepository.Find(x => x.ProductRecipeId == dto.Id).ToList();

            var deletedLines = existingLines.Where(x => !dto.Lines.Any(d => d.Id == x.Id)).ToList();
            foreach (var line in deletedLines)
            {
                _lineRepository.Remove(line);
            }

            foreach (var lineDto in dto.Lines)
            {
                if (lineDto.Id == 0)
                {
                    lineDto.Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId();
                    var newEntity = _mapper.Map<ProductRecipeLine>(lineDto);
                    newEntity.ProductRecipeId = entity.Id;
                    _lineRepository.Add(newEntity);
                }
                else
                {
                    var updateEntity = existingLines.FirstOrDefault(x => x.Id == lineDto.Id);
                    if (updateEntity != null)
                    {
                        _mapper.Map(lineDto, updateEntity);
                        _lineRepository.Update(updateEntity);
                    }
                }
            }

            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }
    }

    public override ProductRecipeDto GetById(long id)
    {
        var entity = _repository.Find(x => x.Id == id).FirstOrDefault();
        if (entity == null) return null;

        var dto = _mapper.Map<ProductRecipeDto>(entity);

        var lines = _lineRepository.Find(x => x.ProductRecipeId == id).ToList();
        dto.Lines = _mapper.Map<List<ProductRecipeLineDto>>(lines);

        foreach (var lineDto in dto.Lines)
        {
            lineDto.MaterialGroupName = lineDto.MaterialType.GetDescription();

            switch (lineDto.MaterialType)
            {
                case MaterialType.MetalAndSheet:
                    lineDto.MaterialName = _serviceProvider.GetService<IMetalSheetGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
                case MaterialType.ElectricalElectronic:
                    lineDto.MaterialName = _serviceProvider.GetService<IElectricalElectronicGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
                case MaterialType.GasAndIgnition:
                    lineDto.MaterialName = _serviceProvider.GetService<IGasAndIgnitionGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
                case MaterialType.PlasticAndVisualParts:
                    lineDto.MaterialName = _serviceProvider.GetService<IPlasticAndVisualPartsGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
                case MaterialType.ChemicalAndInsulation:
                    lineDto.MaterialName = _serviceProvider.GetService<IChemicalAndInsulationGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
                case MaterialType.MechanicalAndHardware:
                    lineDto.MaterialName = _serviceProvider.GetService<IMechanicalAndHardwareGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
                case MaterialType.PackagingAndPrinting:
                    lineDto.MaterialName = _serviceProvider.GetService<IPackagingAndPrintingGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
                case MaterialType.WireAndGrid:
                    lineDto.MaterialName = _serviceProvider.GetService<IWireAndGridGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
                case MaterialType.OtherMaterial:
                    lineDto.MaterialName = _serviceProvider.GetService<IOtherMaterialGroupService>()?.GetById(lineDto.MaterialId)?.Name;
                    break;
            }
        }

        return dto;
    }
}
