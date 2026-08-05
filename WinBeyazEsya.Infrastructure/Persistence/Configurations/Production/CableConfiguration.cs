using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class CableConfiguration : IEntityTypeConfiguration<Cable>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Cable> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);
               
        // Defining precision/scale for decimal length to avoid EF Core truncation warnings
        builder.Property(x => x.LengthMm).HasPrecision(18, 2);
    }
}

