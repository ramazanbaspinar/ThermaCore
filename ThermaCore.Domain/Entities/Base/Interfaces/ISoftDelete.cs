using System;

namespace ThermaCore.Domain.Entities.Base.Interfaces;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
    DateTime? DeletedDate { get; set; }
    long? DeletedUserId { get; set; }
}
