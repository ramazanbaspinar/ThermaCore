using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.EntityConfigurations.Definitions
{
    public class PlasticPartConfiguration : IEntityTypeConfiguration<PlasticPart>
    {
        public void Configure(EntityTypeBuilder<PlasticPart> builder)
        {
            builder.HasIndex(p => p.Code).IsUnique();
            builder.Property(p => p.Code).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.BaseUnit).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Color).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            
            builder.Property(p => p.WeightGr).HasColumnType("decimal(18,2)");
            
            builder.HasOne(p => p.SpecialCode)
                .WithMany()
                .HasForeignKey(p => p.SpecialCodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
