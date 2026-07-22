using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Definitions;

public class UnitConversionConfiguration : IEntityTypeConfiguration<UnitConversion>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<UnitConversion> builder)
    {
        builder.ToTable("UnitConversions");

        builder.Property(uc => uc.Multiplier)
            .HasColumnType("decimal(18,5)");

        builder.Property(uc => uc.Divisor)
            .HasColumnType("decimal(18,5)");

        // Explicitly DO NOT create a foreign key for EntityId
        // This is to allow UnitConversion to be used for any entity without constraints.
        builder.HasIndex(uc => uc.EntityId);
    }
}
