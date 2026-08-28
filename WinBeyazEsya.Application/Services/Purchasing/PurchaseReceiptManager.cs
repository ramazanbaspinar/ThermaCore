using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Purchasing;
using WinBeyazEsya.Application.Interfaces.Purchasing;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Inventory;
using WinBeyazEsya.Domain.Entities.Purchasing;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Application.Services.Purchasing;

public class PurchaseReceiptManager : BaseManager<PurchaseReceiptListDto, PurchaseReceiptDto, PurchaseReceipt>, IPurchaseReceiptService
{
    private readonly IRepository<PurchaseReceiptLine> _lineRepository;
    private readonly IRepository<PurchaseOrder> _orderRepository;
    private readonly IRepository<PurchaseOrderLine> _orderLineRepository;
    private readonly IRepository<StockTransaction> _stockTransactionRepository;

    public PurchaseReceiptManager(
        IMapper mapper,
        IRepository<PurchaseReceipt> repository,
        IUnitOfWork unitOfWork,
        IRepository<PurchaseReceiptLine> lineRepository,
        IRepository<PurchaseOrder> orderRepository,
        IRepository<PurchaseOrderLine> orderLineRepository,
        IRepository<StockTransaction> stockTransactionRepository,
        IValidator<PurchaseReceiptDto>? validator = null)
        : base(mapper, repository, unitOfWork, validator)
    {
        _lineRepository = lineRepository;
        _orderRepository = orderRepository;
        _orderLineRepository = orderLineRepository;
        _stockTransactionRepository = stockTransactionRepository;
    }

    public override PurchaseReceiptDto GetById(long id)
    {
        var dto = base.GetById(id);
        if (dto != null)
        {
            var lines = _lineRepository.Find(x => x.PurchaseReceiptId == id).ToList();
            dto.Lines = _mapper.Map<List<PurchaseReceiptLineDto>>(lines);
        }
        return dto!;
    }

    public override long Insert(PurchaseReceiptDto dto)
    {
        if (_validator != null)
        {
            _validator.ValidateAndThrow(dto);
        }

        var entity = _mapper.Map<PurchaseReceipt>(dto);

        if (entity.Id == 0)
            entity.Id = IdGenerator.GenerateId();

        entity.Lines.Clear();

        if (dto.Lines != null && dto.Lines.Any())
        {
            // Gruplama için ilgili PurchaseOrder ID'lerini toplayalım.
            var orderLineIds = dto.Lines.Where(l => l.PurchaseOrderLineId.HasValue).Select(l => l.PurchaseOrderLineId!.Value).ToList();
            var orderLines = _orderLineRepository.Find(x => orderLineIds.Contains(x.Id)).ToList();

            foreach (var lineDto in dto.Lines)
            {
                var lineEntity = _mapper.Map<PurchaseReceiptLine>(lineDto);
                lineEntity.Id = IdGenerator.GenerateId();
                lineEntity.PurchaseReceiptId = entity.Id;

                // Fallback warehouse id
                if (lineEntity.WarehouseId == null || lineEntity.WarehouseId == 0)
                {
                    lineEntity.WarehouseId = entity.WarehouseId;
                }

                entity.Lines.Add(lineEntity);

                // Stok Hareketi (StockTransaction) Kaydı
                if (lineEntity.WarehouseId.HasValue && lineEntity.WarehouseId.Value > 0)
                {
                    var stockTransaction = new StockTransaction
                    {
                        Id = IdGenerator.GenerateId(),
                        MaterialId = lineEntity.MaterialId,
                        WarehouseId = lineEntity.WarehouseId.Value,
                        DocumentType = DocumentType.PurchaseReceipt,
                        DocumentId = entity.Id,
                        MovementType = MovementType.In,
                        Quantity = lineEntity.Quantity,
                        TransactionDate = entity.ReceiptDate
                    };
                    _stockTransactionRepository.Add(stockTransaction);
                }

                // Sipariş Kalemi Güncellemesi
                if (lineEntity.PurchaseOrderLineId.HasValue)
                {
                    var orderLine = orderLines.FirstOrDefault(x => x.Id == lineEntity.PurchaseOrderLineId.Value);
                    if (orderLine != null)
                    {
                        orderLine.ReceivedQuantity += lineEntity.Quantity;
                        _orderLineRepository.Update(orderLine);
                    }
                }
            }

            // Sipariş Başlık (PurchaseOrder) Statü Güncellemesi
            var orderIdsToUpdate = orderLines.Select(x => x.PurchaseOrderId).Distinct().ToList();
            foreach (var orderId in orderIdsToUpdate)
            {
                var order = _orderRepository.GetById(orderId);
                if (order != null)
                {
                    // Siparişin veritabanındaki tüm satırlarını çekelim
                    var allLinesOfOrder = _orderLineRepository.Find(x => x.PurchaseOrderId == orderId).ToList();

                    // ORM (Entity Framework/Dapper) DbContext'i anında senkronize etmemiş olabilir (SaveChanges henüz çağrılmadı),
                    // bu yüzden o an bellekteki (bu metodda güncellenmiş) ReceivedQuantity değerlerini üzerine yazalım.
                    foreach (var updatedLine in orderLines)
                    {
                        var lineInAll = allLinesOfOrder.FirstOrDefault(x => x.Id == updatedLine.Id);
                        if (lineInAll != null)
                        {
                            lineInAll.ReceivedQuantity = updatedLine.ReceivedQuantity;
                        }
                    }

                    bool isCompleted = allLinesOfOrder.All(x => x.ReceivedQuantity >= x.Quantity);
                    bool isPartial = allLinesOfOrder.Any(x => x.ReceivedQuantity > 0);

                    if (isCompleted)
                    {
                        order.Status = OrderStatus.Completed;
                    }
                    else if (isPartial)
                    {
                        order.Status = OrderStatus.PartialReceived;
                    }

                    _orderRepository.Update(order);
                }
            }
        }

        _repository.Add(entity);

        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public async Task<IEnumerable<PurchaseOrderDispatchListDto>> GetDispatchInfoAsync(long? orderId, long? orderLineId)
    {
        var query = _lineRepository.GetAll();

        if (orderLineId.HasValue && orderLineId.Value > 0)
        {
            query = query.Where(x => x.PurchaseOrderLineId == orderLineId.Value);
        }
        else if (orderId.HasValue && orderId.Value > 0)
        {
            // First get order line ids for this order
            var orderLineIds = _orderLineRepository.Find(x => x.PurchaseOrderId == orderId.Value).Select(x => x.Id).ToList();
            query = query.Where(x => x.PurchaseOrderLineId.HasValue && orderLineIds.Contains(x.PurchaseOrderLineId.Value));
        }
        else
        {
            return new List<PurchaseOrderDispatchListDto>();
        }

        var lines = query.ToList();
        var receiptIds = lines.Select(x => x.PurchaseReceiptId).Distinct().ToList();
        var receipts = _repository.Find(x => receiptIds.Contains(x.Id)).ToList();

        var result = new List<PurchaseOrderDispatchListDto>();

        foreach (var line in lines)
        {
            var receipt = receipts.FirstOrDefault(x => x.Id == line.PurchaseReceiptId);
            if (receipt != null)
            {
                result.Add(new PurchaseOrderDispatchListDto
                {
                    Id = line.Id,
                    MaterialId = line.MaterialId,
                    Quantity = line.Quantity,
                    UnitId = line.UnitId,
                    ReceiptDate = receipt.ReceiptDate,
                    ReceiptCode = receipt.Code,
                    DocumentNo = receipt.DocumentNo ?? string.Empty
                });
            }
        }

        return await Task.FromResult(result);
    }

    public override void Update(PurchaseReceiptDto dto)
    {
        throw new NotImplementedException("Güncelleme işlemi için Sipariş/Stok geri alma (reverse) kurguları gereklidir.");
    }


    public override void Delete(long id)
    {
        throw new NotImplementedException("Silme işlemi için Sipariş/Stok geri alma (reverse) kurguları gereklidir.");
    }
}
