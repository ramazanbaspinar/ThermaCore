using System;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Common;

public class AppDocument : AuditableEntity
{
    public string EntityName { get; set; } = null!;
    public long EntityId { get; set; }
    public string FileName { get; set; } = null!;
    public string Extension { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public long FileSize { get; set; }
    public byte[] FileData { get; set; } = null!;
}
