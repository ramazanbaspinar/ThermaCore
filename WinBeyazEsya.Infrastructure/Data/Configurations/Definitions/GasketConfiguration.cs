using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

using WinBeyazEsya.Infrastructure.Persistence.Configurations;

namespace WinBeyazEsya.Infrastructure.Data.Configurations.Definitions;

public class GasketConfiguration : IEntityTypeConfiguration<Gasket>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Gasket> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.LengthMm).HasColumnType("decimal(18,2)");
        
        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

