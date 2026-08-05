using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Infrastructure.Persistence.Configurations;

namespace WinBeyazEsya.Infrastructure.Configurations.Definitions;

public class HandleConfiguration : IEntityTypeConfiguration<Handle>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Handle> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.LengthMm).HasColumnType("decimal(18,2)");
        builder.Property(x => x.WeightGr).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

