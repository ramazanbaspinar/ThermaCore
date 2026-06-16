using System;

namespace ThermaCore.Domain.Entities.Base.Interfaces;

public interface IAuditableEntity
{
    DateTime CreatedDate { get; set; }
    long CreatedUserId { get; set; }
    DateTime? ModifiedDate { get; set; }
    long? ModifiedUserId { get; set; }
}
