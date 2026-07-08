using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class RotarySwitchConfiguration : IEntityTypeConfiguration<RotarySwitch>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<RotarySwitch> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
