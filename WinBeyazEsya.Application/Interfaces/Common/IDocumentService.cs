using System.Collections.Generic;
using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Common;

namespace WinBeyazEsya.Application.Interfaces.Common;

public interface IDocumentService
{
    Task<AppDocumentDto> UploadDocumentAsync(AppDocumentDto dto);
    Task<List<AppDocumentDto>> GetDocumentsByEntityAsync(string entityName, long entityId);
    Task DeleteDocumentAsync(long id);
}

