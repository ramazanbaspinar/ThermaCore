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
    private readonly WinBeyazEsya.Application.Services.Management.IAuthService _authService;
    private readonly WinBeyazEsya.Application.Interfaces.Mailing.IMailService _mailService;
    private readonly IRepository<WinBeyazEsya.Domain.Entities.Production.RawMaterial> _rawMaterialRepository;
    private readonly IRepository<WinBeyazEsya.Domain.Entities.Definitions.Unit> _unitRepository;
    private readonly IRepository<WinBeyazEsya.Domain.Entities.Definitions.Warehouse> _warehouseRepository;

    public PurchaseOrderManager(
        IMapper mapper,
        IRepository<PurchaseOrder> repository,
        IUnitOfWork unitOfWork,
        IRepository<PurchaseOrderLine> lineRepository,
        WinBeyazEsya.Application.Services.Management.IAuthService authService,
        WinBeyazEsya.Application.Interfaces.Mailing.IMailService mailService,
        IRepository<WinBeyazEsya.Domain.Entities.Production.RawMaterial> rawMaterialRepository,
        IRepository<WinBeyazEsya.Domain.Entities.Definitions.Unit> unitRepository,
        IRepository<WinBeyazEsya.Domain.Entities.Definitions.Warehouse> warehouseRepository,
        IValidator<PurchaseOrderDto>? validator = null)
        : base(mapper, repository, unitOfWork, validator)
    {
        _lineRepository = lineRepository;
        _authService = authService;
        _mailService = mailService;
        _rawMaterialRepository = rawMaterialRepository;
        _unitRepository = unitRepository;
        _warehouseRepository = warehouseRepository;
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

        // AutoMapper otomatik olarak Lines listesini doldurduğu için onları temizleyelim
        // Çünkü aşağıda manuel olarak ID atayıp tekrar ekliyoruz.
        entity.Lines.Clear();

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

        bool isSentToApproval = existingEntity.Status == WinBeyazEsya.Domain.Enums.OrderStatus.Draft &&
                                dto.Status == WinBeyazEsya.Domain.Enums.OrderStatus.WaitingApproval;

        _mapper.Map(dto, existingEntity);

        // AutoMapper'ın kendi kendine eklediği id=0 olan satırları entity'den kopartalım
        existingEntity.Lines.Clear();

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

        if (isSentToApproval)
        {
            try
            {
                var users = _authService.GetUsersWithSpecialPermission(WinBeyazEsya.Domain.Enums.ModuleType.SatinalmaSiparisleri, "CanReceiveApprovalEmails");
                var emails = users.Where(u => !string.IsNullOrWhiteSpace(u.Email)).Select(u => u.Email!).ToList();

                if (emails.Any())
                {
                    string subject = $"Sipariş Onayı Bekleniyor - Sipariş No: {existingEntity.Code}";
                    string body = $"Satınalma Modülü - {existingEntity.Code} numaralı sipariş onayınızı beklemektedir.";
                    _ = _mailService.SendMailAsync(emails, subject, body);
                }
            }
            catch { }
        }
    }

    public override void Delete(long id)
    {
        var existingEntity = _repository.GetById(id);
        if (existingEntity == null) throw new global::System.Exception("Silinmek istenen satınalma siparişi bulunamadı.");

        if (existingEntity.Status != WinBeyazEsya.Domain.Enums.OrderStatus.Draft &&
            existingEntity.Status != WinBeyazEsya.Domain.Enums.OrderStatus.WaitingApproval)
        {
            throw new global::System.Exception("GÜVENLİK KISITLAMASI: Onaylanmış veya işlem görmüş siparişler silinemez! Silmek için önce onayını geri çekmelisiniz.");
        }

        // Bağımlı satırların temizlenmesi (Eğer cascade delete yoksa zorunlu)
        var lines = _lineRepository.Find(x => x.PurchaseOrderId == id).ToList();
        foreach (var line in lines)
        {
            _lineRepository.Remove(line);
        }

        // Kalkanı geçtiyse asıl silme işlemini base'e devret
        base.Delete(id);
    }

    public async Task<List<PurchaseOrderLineTransferListDto>> GetOpenOrderLinesAsync(long supplierId)
    {
        // _lineRepository üzerinden Include işlemi yapıyoruz (x => x.PurchaseOrder).
        // IRepository.GetAll() parametre olarak params Expression<Func<T, object>>[] includes alıyor.
        var query = _lineRepository.GetAll(x => x.PurchaseOrder)
            .Where(x => !x.IsDeleted &&
                        x.PurchaseOrder.SupplierId == supplierId &&
                        !x.PurchaseOrder.IsDeleted &&
                        (x.PurchaseOrder.Status == WinBeyazEsya.Domain.Enums.OrderStatus.Approved ||
                         x.PurchaseOrder.Status == WinBeyazEsya.Domain.Enums.OrderStatus.PartialReceived) &&
                        (x.Quantity - x.ReceivedQuantity) > 0);

        var list = query.ToList();

        var dtoList = new List<PurchaseOrderLineTransferListDto>();
        foreach (var item in list)
        {
            var dto = new PurchaseOrderLineTransferListDto
            {
                PurchaseOrderId = item.PurchaseOrderId,
                PurchaseOrderLineId = item.Id,
                OrderDate = item.PurchaseOrder.OrderDate,
                Code = item.PurchaseOrder.Code,
                DocumentNo = item.PurchaseOrder.DocumentNo ?? item.PurchaseOrder.Code,
                MaterialId = item.MaterialId,
                Quantity = item.Quantity,
                ReceivedQuantity = item.ReceivedQuantity,
                PendingQuantity = item.Quantity - item.ReceivedQuantity,
                UnitId = item.UnitId,
                UnitName = _unitRepository.Find(x => x.Id == item.UnitId).FirstOrDefault()?.Name,
                UnitPrice = item.UnitPrice,
                TaxRate = item.TaxRate,
                WarehouseId = item.WarehouseId ?? item.PurchaseOrder.WarehouseId,
                WarehouseName = _warehouseRepository.Find(x => x.Id == (item.WarehouseId ?? item.PurchaseOrder.WarehouseId)).FirstOrDefault()?.Name,
                CurrencyCode = item.PurchaseOrder.CurrencyCode,
                PendingLineTotal = (item.Quantity - item.ReceivedQuantity) * item.UnitPrice,
                DeliveryDate = item.PurchaseOrder.DeliveryDate
            };
            dtoList.Add(dto);
        }

        return await Task.FromResult(dtoList);
    }
}
