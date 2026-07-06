using System.Collections.Generic;
using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Common;

namespace ThermaCore.Application.Interfaces.Common;

public interface IDocumentService
{
    Task<AppDocumentDto> UploadDocumentAsync(AppDocumentDto dto);
    Task<List<AppDocumentDto>> GetDocumentsByEntityAsync(string entityName, long entityId);
    Task DeleteDocumentAsync(long id);
}
