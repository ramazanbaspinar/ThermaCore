using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class OvenGlassConfiguration : IEntityTypeConfiguration<OvenGlass>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<OvenGlass> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.GlassType)
               .WithMany()
               .HasForeignKey(x => x.GlassTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ColorFeature)
               .WithMany()
               .HasForeignKey(x => x.ColorFeatureId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
