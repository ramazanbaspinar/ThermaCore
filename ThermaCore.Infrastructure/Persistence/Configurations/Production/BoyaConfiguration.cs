using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Production;

public class BoyaConfiguration : ITenantEntityConfiguration, IEntityTypeConfiguration<Boya>
{
    public void Configure(EntityTypeBuilder<Boya> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Code).IsUnique();
        
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.BaseUnit)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ColorCode)
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
