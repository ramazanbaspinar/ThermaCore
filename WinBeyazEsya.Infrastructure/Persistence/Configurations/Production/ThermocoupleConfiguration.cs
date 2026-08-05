using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class ThermocoupleConfiguration : IEntityTypeConfiguration<Thermocouple>
{
    public void Configure(EntityTypeBuilder<Thermocouple> builder)
    {
        builder.ToTable("Thermocouples");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(20);

        builder.Property(x => x.HeadType).HasMaxLength(50);
        builder.Property(x => x.TipType).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(500);
        
        builder.Property(x => x.LengthMm).HasPrecision(18, 2);

        // SpecialCode relation
        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

