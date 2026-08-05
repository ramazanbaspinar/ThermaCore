using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations;

public class FastenerConfiguration : IEntityTypeConfiguration<Fastener>
{
    public void Configure(EntityTypeBuilder<Fastener> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.WeightGr)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.QualityStandard)
            .WithMany()
            .HasForeignKey(x => x.QualityStandardId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

