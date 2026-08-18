namespace WinBeyazEsya.Application.DTOs.Base;

public abstract class BaseDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    // Audit alanları (AuditableEntity → AutoMapper convention-based mapping)
    public DateTime? CreatedDate { get; set; }
    public long? CreatedUserId { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifiedUserId { get; set; }
}

