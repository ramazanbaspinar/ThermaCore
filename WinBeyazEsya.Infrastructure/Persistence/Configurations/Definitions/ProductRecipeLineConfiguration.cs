using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class ProductRecipeLineConfiguration : IEntityTypeConfiguration<ProductRecipeLine>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ProductRecipeLine> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity).HasPrecision(18, 4);
        builder.Property(x => x.WasteRate).HasPrecision(18, 4);

        builder.Property(x => x.WeightKg).HasPrecision(18, 6);
        builder.Property(x => x.CoatingAmount).HasPrecision(18, 2);
        builder.Property(x => x.UnitPrice).HasPrecision(18, 4);
        builder.Property(x => x.TotalMaterialCost).HasPrecision(18, 4);
        builder.Property(x => x.ManualCoatingCost).HasPrecision(18, 4);

        builder.HasOne(x => x.ProductRecipe)
            .WithMany(x => x.Lines)
            .HasForeignKey(x => x.ProductRecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Unit)
            .WithMany()
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
