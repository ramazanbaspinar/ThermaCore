using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class GlassTypeConfiguration : IEntityTypeConfiguration<GlassType>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<GlassType> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
    }
}

