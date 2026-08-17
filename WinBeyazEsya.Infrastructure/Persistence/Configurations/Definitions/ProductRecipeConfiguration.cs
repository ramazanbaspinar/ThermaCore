using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class ProductRecipeConfiguration : IEntityTypeConfiguration<ProductRecipe>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ProductRecipe> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code).HasMaxLength(50).IsRequired();
        builder.HasIndex(x => new { x.Code, x.RevisionNumber }).IsUnique();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500);
        
        builder.Property(x => x.TotalCost).HasColumnType("decimal(18,4)");
        builder.Property(x => x.ExchangeRate).HasColumnType("decimal(18,4)");
        builder.Property(x => x.NetMaterialCost).HasPrecision(18, 4);

        builder.HasOne(x => x.FinishedGood)
            .WithMany()
            .HasForeignKey(x => x.FinishedGoodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
