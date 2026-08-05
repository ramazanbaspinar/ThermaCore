using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class GasPipeConfiguration : IEntityTypeConfiguration<GasPipe>
{
    public void Configure(EntityTypeBuilder<GasPipe> builder)
    {
        builder.HasIndex(x => new { x.Code, x.IsDeleted }).IsUnique();

        builder.Property(x => x.LengthMm).HasColumnType("decimal(18,2)");
        
        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

