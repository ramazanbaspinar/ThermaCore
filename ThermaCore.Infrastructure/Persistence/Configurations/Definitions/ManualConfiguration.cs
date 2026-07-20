using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Definitions;

public class ManualConfiguration : ITenantEntityConfiguration, IEntityTypeConfiguration<Manual>
{
    public void Configure(EntityTypeBuilder<Manual> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
