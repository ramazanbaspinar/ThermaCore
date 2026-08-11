using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Management;

public class TaxRateConfiguration : IEntityTypeConfiguration<TaxRate>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<TaxRate> builder)
    {
        builder.ToTable("TaxRates");

        builder.Property(x => x.Code)
            .HasMaxLength(50);

        builder.Property(x => x.Rate)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Description)
            .IsRequired(false);
    }
}

