using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Yonetim;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Yonetim;

public class ModulIslemYetkisiConfiguration : IEntityTypeConfiguration<ModulIslemYetkisi>
{
    public void Configure(EntityTypeBuilder<ModulIslemYetkisi> builder)
    {
        builder.ToTable("ModulIslemYetkileri");

        builder.HasOne(x => x.KullaniciRolu)
            .WithMany()
            .HasForeignKey(x => x.KullaniciRoluId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
