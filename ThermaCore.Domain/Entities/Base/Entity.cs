using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThermaCore.Domain.Entities.Base;

public abstract class Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;
}
