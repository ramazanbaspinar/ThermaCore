using System;

namespace WinBeyazEsya.Application.DTOs.Common;

public class AppDocumentDto
{
    public long Id { get; set; }
    public string EntityName { get; set; } = null!;
    public long EntityId { get; set; }
    public string FileName { get; set; } = null!;
    public string Extension { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public long FileSize { get; set; }
    public byte[] FileData { get; set; } = null!;
}

