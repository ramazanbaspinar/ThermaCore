using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class TownConfiguration : IEntityTypeConfiguration<Town>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Town> builder)
    {
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
        builder.Property(x => x.CityCode).HasMaxLength(13);
        builder.Property(x => x.TownCode).HasMaxLength(13);
    }
}
