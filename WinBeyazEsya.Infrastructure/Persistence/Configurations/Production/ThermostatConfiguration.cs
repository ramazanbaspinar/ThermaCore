using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class ThermostatConfiguration : IEntityTypeConfiguration<Thermostat>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Thermostat> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.CapillaryLengthMm).HasPrecision(18, 2);

        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

