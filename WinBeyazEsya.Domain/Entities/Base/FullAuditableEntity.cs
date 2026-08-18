namespace WinBeyazEsya.Domain.Entities.Base;

public abstract class FullAuditableEntity : AuditableEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedDate { get; set; }
    public long? DeletedUserId { get; set; }
}

