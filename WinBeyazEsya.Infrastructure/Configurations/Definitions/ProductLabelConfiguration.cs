using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Configurations.Definitions;

public class ProductLabelConfiguration : IEntityTypeConfiguration<ProductLabel>
{
    public void Configure(EntityTypeBuilder<ProductLabel> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.WidthMm).HasColumnType("decimal(18,2)");
        builder.Property(x => x.HeightMm).HasColumnType("decimal(18,2)");
        
        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

