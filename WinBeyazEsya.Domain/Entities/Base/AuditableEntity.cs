namespace WinBeyazEsya.Domain.Entities.Base;

public abstract class AuditableEntity : Entity
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public long CreatedUserId { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifiedUserId { get; set; }
}

