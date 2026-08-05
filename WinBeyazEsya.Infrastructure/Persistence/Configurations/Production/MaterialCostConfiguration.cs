using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class MaterialCostConfiguration : ITenantEntityConfiguration, IEntityTypeConfiguration<MaterialCost>
{
    public void Configure(EntityTypeBuilder<MaterialCost> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.MaterialType)
            .IsRequired();

        builder.Property(x => x.MaterialId)
            .IsRequired();

        builder.Property(x => x.Cost)
            .IsRequired()
            .HasColumnType("decimal(18,4)");

        builder.Property(x => x.CurrencyCode)
            .IsRequired()
            .HasMaxLength(5);
    }
}

