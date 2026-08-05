using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class OvenLampConfiguration : IEntityTypeConfiguration<OvenLamp>
{
    public void Configure(EntityTypeBuilder<OvenLamp> builder)
    {
        builder.ToTable("OvenLamps");
        
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(50);
        builder.Property(x => x.SocketType).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(500);

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

