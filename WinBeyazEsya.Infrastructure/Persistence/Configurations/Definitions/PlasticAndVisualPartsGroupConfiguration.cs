using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class PlasticAndVisualPartsGroupConfiguration : IEntityTypeConfiguration<PlasticAndVisualPartsGroup>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<PlasticAndVisualPartsGroup> builder)
    {
        builder.ToTable("PlasticAndVisualPartsGroups");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Code).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        
        builder.Property(x => x.Description).HasMaxLength(500);

        builder.HasOne(x => x.BaseUnit)
            .WithMany()
            .HasForeignKey(x => x.BaseUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasIndex(x => x.Code);
        builder.HasIndex(x => x.BranchId);
    }
}
