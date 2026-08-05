using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Management;

public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.CurrencyCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.EffectiveBuyingRate).HasColumnType("decimal(18,4)");
        builder.Property(e => e.EffectiveSellingRate).HasColumnType("decimal(18,4)");
        builder.Property(e => e.TcmbBuyingRate).HasColumnType("decimal(18,4)");
        builder.Property(e => e.TcmbSellingRate).HasColumnType("decimal(18,4)");
    }
}

