using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Purchasing;
using WinBeyazEsya.Application.Interfaces.Purchasing;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Purchasing;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Application.Services.Purchasing;

public class PurchaseOrderManager : BaseManager<PurchaseOrderListDto, PurchaseOrderDto, PurchaseOrder>, IPurchaseOrderService
{
    private readonly IRepository<PurchaseOrderLine> _lineRepository;

    public PurchaseOrderManager(
        IMapper mapper,
        IRepository<PurchaseOrder> repository,
        IUnitOfWork unitOfWork,
        IRepository<PurchaseOrderLine> lineRepository,
        IValidator<PurchaseOrderDto>? validator = null)
        : base(mapper, repository, unitOfWork, validator)
    {
        _lineRepository = lineRepository;
    }

    public override PurchaseOrderDto GetById(long id)
    {
        var dto = base.GetById(id);
        if (dto != null)
        {
            var lines = _lineRepository.Find(x => x.PurchaseOrderId == id).ToList();
            dto.Lines = _mapper.Map<List<PurchaseOrderLineDto>>(lines);
        }
        return dto!;
    }

    public override long Insert(PurchaseOrderDto dto)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(dto);
        }

        var entity = _mapper.Map<PurchaseOrder>(dto);
        
        // Let AutoMapper and DB handle IDs if IdGenerator is not strictly needed for primary entity,
        // but typically in this structure IdGenerator is used. We'll assign it here.
        if (entity.Id == 0)
            entity.Id = IdGenerator.GenerateId();

        if (dto.Lines != null && dto.Lines.Any())
        {
            foreach (var lineDto in dto.Lines)
            {
                var lineEntity = _mapper.Map<PurchaseOrderLine>(lineDto);
                lineEntity.Id = IdGenerator.GenerateId();
                lineEntity.PurchaseOrderId = entity.Id;
                entity.Lines.Add(lineEntity);
            }
        }

        _repository.Add(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public override void Update(PurchaseOrderDto dto)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(dto);
        }

        var existingEntity = _repository.GetById(dto.Id);
        if (existingEntity == null) throw new Exception("Satınalma siparişi bulunamadı.");

        _mapper.Map(dto, existingEntity);

        // Remove old lines
        var existingLines = _lineRepository.Find(x => x.PurchaseOrderId == existingEntity.Id).ToList();
        foreach (var line in existingLines)
        {
            _lineRepository.Remove(line);
        }

        // Add new lines
        if (dto.Lines != null && dto.Lines.Any())
        {
            foreach (var lineDto in dto.Lines)
            {
                var lineEntity = _mapper.Map<PurchaseOrderLine>(lineDto);
                lineEntity.Id = IdGenerator.GenerateId();
                lineEntity.PurchaseOrderId = existingEntity.Id;
                _lineRepository.Add(lineEntity);
            }
        }

        _repository.Update(existingEntity);
        _unitOfWork.SaveChanges();
    }
}
