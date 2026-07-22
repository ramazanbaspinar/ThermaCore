using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IProductLabelService
{
    IEnumerable<ProductLabelListDto> GetAll();
    ProductLabelDto GetById(long id);
    long Insert(ProductLabelDto dto);
    void Update(ProductLabelDto dto);
    void Delete(long id);
}
