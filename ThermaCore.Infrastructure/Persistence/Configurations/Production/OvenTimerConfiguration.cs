using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;
using ThermaCore.Infrastructure.Persistence.Configurations.Common;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class OvenTimerConfiguration : IEntityTypeConfiguration<OvenTimer>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<OvenTimer> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
