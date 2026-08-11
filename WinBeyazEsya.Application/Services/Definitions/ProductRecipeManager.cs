using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class ProductRecipeManager : BaseManager<ProductRecipeListDto, ProductRecipeDto, ProductRecipe>, IProductRecipeService
{
    private readonly IRepository<ProductRecipeLine> _lineRepository;

    public ProductRecipeManager(
        IMapper mapper,
        IRepository<ProductRecipe> repository,
        IRepository<ProductRecipeLine> lineRepository,
        IUnitOfWork unitOfWork,
        IValidator<ProductRecipeDto>? validator = null)
        : base(mapper, repository, unitOfWork, validator)
    {
        _lineRepository = lineRepository;
    }

    public override long Insert(ProductRecipeDto dto)
    {
        _validator?.ValidateAndThrow(dto);
        
        var entity = _mapper.Map<ProductRecipe>(dto);
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
            foreach(var line in deletedLines)
            {
                _lineRepository.Remove(line);
            }

            foreach(var lineDto in dto.Lines)
            {
                if (lineDto.Id == 0)
                {
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
        
        return dto;
    }
}
