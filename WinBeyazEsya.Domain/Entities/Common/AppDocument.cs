using System;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Common;

public class AppDocument : AuditableEntity, IMustHaveBranch
{
    public string EntityName { get; set; } = null!;
    public long EntityId { get; set; }
    public string FileName { get; set; } = null!;
    public string Extension { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public long FileSize { get; set; }
    public byte[] FileData { get; set; } = null!;
    
    public long BranchId { get; set; }
}

