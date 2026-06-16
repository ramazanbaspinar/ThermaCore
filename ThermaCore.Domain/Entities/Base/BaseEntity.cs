using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThermaCore.Domain.Entities.Base.Interfaces;

namespace ThermaCore.Domain.Entities.Base;

public abstract class BaseEntity : IBaseEntity, IAuditableEntity, ISoftDelete
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    public virtual string Kod { get; set; } = string.Empty;

    public bool Durum { get; set; } = true;

    // IAuditableEntity
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public long CreatedUserId { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifiedUserId { get; set; }

    // ISoftDelete
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedDate { get; set; }
    public long? DeletedUserId { get; set; }
}
