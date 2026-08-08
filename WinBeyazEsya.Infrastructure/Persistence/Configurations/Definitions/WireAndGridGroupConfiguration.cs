using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class WireAndGridGroupConfiguration : IEntityTypeConfiguration<WireAndGridGroup>
{
    public void Configure(EntityTypeBuilder<WireAndGridGroup> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);
            
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);
            
        builder.HasIndex(x => x.Code)
            .IsUnique();
            
        builder.HasOne(x => x.BaseUnit)
            .WithMany()
            .HasForeignKey(x => x.BaseUnitId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
