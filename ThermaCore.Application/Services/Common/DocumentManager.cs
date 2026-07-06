using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Common;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Common;

namespace ThermaCore.Application.Services.Common;

public class DocumentManager : IDocumentService
{
    private readonly IRepository<AppDocument> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DocumentManager(IRepository<AppDocument> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AppDocumentDto> UploadDocumentAsync(AppDocumentDto dto)
    {
        var entity = new AppDocument
        {
            Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
            EntityName = dto.EntityName,
            EntityId = dto.EntityId,
            FileName = dto.FileName,
            Extension = dto.Extension,
            ContentType = dto.ContentType,
            FileSize = dto.FileSize,
            FileData = dto.FileData
        };

        _repository.Add(entity);
        await _unitOfWork.SaveChangesAsync();

        dto.Id = entity.Id;
        return dto;
    }

    public Task<List<AppDocumentDto>> GetDocumentsByEntityAsync(string entityName, long entityId)
    {
        var documents = _repository.Find(x => x.EntityName == entityName && x.EntityId == entityId).ToList();
        
        var result = documents.Select(x => new AppDocumentDto
        {
            Id = x.Id,
            EntityName = x.EntityName,
            EntityId = x.EntityId,
            FileName = x.FileName,
            Extension = x.Extension,
            ContentType = x.ContentType,
            FileSize = x.FileSize,
            FileData = x.FileData
        }).ToList();

        return Task.FromResult(result);
    }

    public async Task DeleteDocumentAsync(long id)
    {
        var entity = _repository.GetById(id);
        if (entity != null)
        {
            _repository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
