using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations;

public class HotplateConfiguration : IEntityTypeConfiguration<Hotplate>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Hotplate> builder)
    {
        builder.ToTable("Hotplates");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Description).HasMaxLength(500);

        builder.Property(x => x.DiameterMm).HasColumnType("decimal(18,2)");

        // Index
        builder.HasIndex(x => x.Code).IsUnique();

        // Relations
        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
