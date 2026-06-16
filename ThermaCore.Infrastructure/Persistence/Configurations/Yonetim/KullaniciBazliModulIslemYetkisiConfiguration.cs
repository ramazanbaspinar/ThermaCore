using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Yonetim;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Yonetim;

public class KullaniciBazliModulIslemYetkisiConfiguration : IEntityTypeConfiguration<KullaniciBazliModulIslemYetkisi>
{
    public void Configure(EntityTypeBuilder<KullaniciBazliModulIslemYetkisi> builder)
    {
        builder.ToTable("KullaniciBazliModulIslemYetkileri");

        builder.HasOne(x => x.Kullanici)
            .WithMany()
            .HasForeignKey(x => x.KullaniciId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
