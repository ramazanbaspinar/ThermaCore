using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class PackagingMaterialConfiguration : ITenantEntityConfiguration, IEntityTypeConfiguration<PackagingMaterial>
{
    public void Configure(EntityTypeBuilder<PackagingMaterial> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.ThicknessMm)
            .HasColumnType("decimal(18,2)");
            
        builder.Property(x => x.WeightGr)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

