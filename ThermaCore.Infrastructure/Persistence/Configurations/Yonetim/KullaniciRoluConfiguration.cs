using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Yonetim;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Yonetim;

public class KullaniciRoluConfiguration : IEntityTypeConfiguration<KullaniciRolu>
{
    public void Configure(EntityTypeBuilder<KullaniciRolu> builder)
    {
        builder.ToTable("KullaniciRolleri");

        builder.Property(x => x.RolAdi)
            .IsRequired()
            .HasMaxLength(50);
    }
}
