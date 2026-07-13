using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class BurnerConfiguration : IEntityTypeConfiguration<Burner>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Burner> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.PowerKw).HasColumnType("decimal(18,2)");
        builder.Property(x => x.SizeMm).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
