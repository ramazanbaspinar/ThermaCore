using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Infrastructure.Persistence.Configurations;

namespace ThermaCore.Infrastructure.Configurations.Definitions;

public class FittingConfiguration : IEntityTypeConfiguration<Fitting>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Fitting> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.WeightGr)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
