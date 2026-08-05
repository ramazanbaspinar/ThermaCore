using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;
using WinBeyazEsya.Infrastructure.Persistence.Configurations.Common;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class OvenTimerConfiguration : IEntityTypeConfiguration<OvenTimer>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<OvenTimer> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasOne(x => x.SpecialCode)
               .WithMany()
               .HasForeignKey(x => x.SpecialCodeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

