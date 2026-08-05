using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class ColorFeatureConfiguration : IEntityTypeConfiguration<ColorFeature>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ColorFeature> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
    }
}

