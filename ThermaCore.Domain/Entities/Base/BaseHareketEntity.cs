using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThermaCore.Domain.Entities.Base.Interfaces;

namespace ThermaCore.Domain.Entities.Base;

public abstract class BaseHareketEntity : IAuditableEntity, ISoftDelete, IBaseHareketEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }

    // IAuditableEntity
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public long CreatedUserId { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifiedUserId { get; set; }

    // ISoftDelete
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedDate { get; set; }
    public long? DeletedUserId { get; set; }

    // UI Tracking (NotMapped)
    [NotMapped]
    public bool Insert { get; set; }

    [NotMapped]
    public bool Update { get; set; }

    [NotMapped]
    public bool Delete { get; set; }
}
