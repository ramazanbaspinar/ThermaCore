using Microsoft.EntityFrameworkCore;
using ThermaCore.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.Data.Configurations.Definitions;

public class WireConfiguration : IEntityTypeConfiguration<Wire>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Wire> builder)
    {
        builder.ToTable("Wires");

        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(20);
        
        builder.Property(x => x.DiameterMm).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Description).HasMaxLength(500);

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
