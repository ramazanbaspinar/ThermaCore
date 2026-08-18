using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Common;

public class SpecialCodeConfiguration : IEntityTypeConfiguration<SpecialCode>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<SpecialCode> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.EntityType).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(250);

        builder.HasIndex(x => new { x.CodeType, x.EntityType, x.Code }).IsUnique();
    }
}

