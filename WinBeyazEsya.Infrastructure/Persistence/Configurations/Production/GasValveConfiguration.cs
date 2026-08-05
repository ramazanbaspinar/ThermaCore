using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class GasValveConfiguration : IEntityTypeConfiguration<GasValve>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<GasValve> builder)
    {
        builder.ToTable("GasValves");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.ShaftType).HasMaxLength(50);

        // Index
        builder.HasIndex(x => x.Code).IsUnique();

        // Relations
        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

