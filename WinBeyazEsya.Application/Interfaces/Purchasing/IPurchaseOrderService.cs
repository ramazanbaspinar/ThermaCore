using WinBeyazEsya.Application.DTOs.Purchasing;

namespace WinBeyazEsya.Application.Interfaces.Purchasing;

public interface IPurchaseOrderService
{
    PurchaseOrderDto GetById(long id);
    IEnumerable<PurchaseOrderListDto> GetAll();
    long Insert(PurchaseOrderDto dto);
    void Update(PurchaseOrderDto dto);
    void Delete(long id);
    Task<List<PurchaseOrderLineTransferListDto>> GetOpenOrderLinesAsync(long supplierId);
}
