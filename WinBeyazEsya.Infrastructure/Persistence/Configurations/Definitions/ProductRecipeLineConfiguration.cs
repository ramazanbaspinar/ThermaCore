using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class ProductRecipeLineConfiguration : IEntityTypeConfiguration<ProductRecipeLine>
{
    public void Configure(EntityTypeBuilder<ProductRecipeLine> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Quantity).HasPrecision(18, 4);
        builder.Property(x => x.WasteRate).HasPrecision(18, 4);

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
