using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Infrastructure.Persistence.Configurations;

namespace ThermaCore.Infrastructure.Data.Configurations.Definitions;

public class InsulationConfiguration : IEntityTypeConfiguration<Insulation>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Insulation> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.ThicknessMm).HasColumnType("decimal(18,2)");
        
        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
