using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class MetalSheetGroupConfiguration : IEntityTypeConfiguration<MetalSheetGroup>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<MetalSheetGroup> builder)
    {
        builder.ToTable("MetalSheetGroups");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.Width).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Length).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Thickness).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Density).HasColumnType("decimal(18,6)");
        builder.Property(x => x.Weight).HasColumnType("decimal(18,6)");
        
        builder.Property(x => x.SurfaceType).HasMaxLength(100);
        builder.Property(x => x.QualityCode).HasMaxLength(100);
        builder.Property(x => x.SurfaceCoatingType).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500);

        builder.HasOne(x => x.BaseUnit)
            .WithMany()
            .HasForeignKey(x => x.BaseUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.BranchId);
    }
}

