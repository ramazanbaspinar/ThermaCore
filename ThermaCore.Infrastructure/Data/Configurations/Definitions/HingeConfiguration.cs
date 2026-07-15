using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.Data.Configurations.Definitions;

public class HingeConfiguration : IEntityTypeConfiguration<Hinge>
{
    public void Configure(EntityTypeBuilder<Hinge> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.LoadCapacityKg)
            .HasColumnType("decimal(18,2)");
    }
}
