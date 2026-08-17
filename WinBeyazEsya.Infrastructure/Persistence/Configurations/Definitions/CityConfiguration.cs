using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class CityConfiguration : IEntityTypeConfiguration<City>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
        builder.Property(x => x.CountryCode).HasMaxLength(13);

        builder.HasIndex(x => x.Code);
        builder.HasIndex(x => x.LogicalRef).IsUnique().HasFilter("[LogicalRef] > 0");
    }
}
