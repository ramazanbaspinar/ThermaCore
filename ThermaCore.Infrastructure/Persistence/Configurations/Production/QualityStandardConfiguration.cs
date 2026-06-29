using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class QualityStandardConfiguration : IEntityTypeConfiguration<QualityStandard>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<QualityStandard> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(500);
    }
}
