using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class SheetMetalConfiguration : ITenantEntityConfiguration, IEntityTypeConfiguration<SheetMetal>
{
    public void Configure(EntityTypeBuilder<SheetMetal> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Thickness)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Density)
            .HasColumnType("decimal(18,4)")
            .HasDefaultValue(7.85m);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.HasOne(x => x.SheetMetalType)
            .WithMany()
            .HasForeignKey(x => x.SheetMetalTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.QualityStandard)
            .WithMany()
            .HasForeignKey(x => x.QualityStandardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SurfaceType)
            .WithMany()
            .HasForeignKey(x => x.SurfaceTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Unit)
            .WithMany()
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
