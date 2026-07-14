using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class ValveConfiguration : IEntityTypeConfiguration<Valve>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Valve> builder)
    {
        builder.ToTable("Valve");
        
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.Code).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(50);
        
        builder.Property(x => x.MaxPressureMbar).HasColumnType("decimal(18,2)");
        builder.Property(x => x.ConnectionSize).HasMaxLength(100);
        builder.Property(x => x.TemperatureRange).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(500);

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
