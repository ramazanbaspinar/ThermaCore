using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class SparkPlugConfiguration : IEntityTypeConfiguration<SparkPlug>
{
    public void Configure(EntityTypeBuilder<SparkPlug> builder)
    {
        builder.ToTable("SparkPlugs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(20);

        builder.Property(x => x.LengthMm).HasPrecision(18, 2);
        builder.Property(x => x.ConnectionType).HasMaxLength(50);
        builder.Property(x => x.SparkTipType).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(500);

        // SpecialCode relation
        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

