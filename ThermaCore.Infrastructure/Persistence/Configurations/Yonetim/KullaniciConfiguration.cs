using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Yonetim;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Yonetim;

public class KullaniciConfiguration : IEntityTypeConfiguration<Kullanici>
{
    public void Configure(EntityTypeBuilder<Kullanici> builder)
    {
        builder.ToTable("Kullanicilar");

        builder.HasOne(x => x.KullaniciRolu)
            .WithMany()
            .HasForeignKey(x => x.KullaniciRoluId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
