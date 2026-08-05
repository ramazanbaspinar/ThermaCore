using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Data.Configurations.Definitions;

public class HingeConfiguration : IEntityTypeConfiguration<Hinge>
{
    public void Configure(EntityTypeBuilder<Hinge> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.LoadCapacityKg)
            .HasColumnType("decimal(18,2)");
    }
}

