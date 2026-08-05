using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Data.Configurations.Definitions;

public class TrayConfiguration : IEntityTypeConfiguration<Tray>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Tray> builder)
    {
        builder.ToTable("Trays");

        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(20);
        
        builder.Property(x => x.WidthMm).HasColumnType("decimal(18,2)");
        builder.Property(x => x.DepthMm).HasColumnType("decimal(18,2)");
        builder.Property(x => x.ThicknessMm).HasColumnType("decimal(18,2)");
        builder.Property(x => x.WeightGr).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Description).HasMaxLength(500);

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

