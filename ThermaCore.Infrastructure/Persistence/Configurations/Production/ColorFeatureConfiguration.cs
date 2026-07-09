using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class ColorFeatureConfiguration : IEntityTypeConfiguration<ColorFeature>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ColorFeature> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
    }
}
