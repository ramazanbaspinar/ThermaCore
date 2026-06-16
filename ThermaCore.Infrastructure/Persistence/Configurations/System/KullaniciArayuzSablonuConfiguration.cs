using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Persistence.Configurations.System;

public class KullaniciArayuzSablonuConfiguration : IEntityTypeConfiguration<KullaniciArayuzSablonu>
{
    public void Configure(EntityTypeBuilder<KullaniciArayuzSablonu> builder)
    {
        builder.ToTable("KullaniciArayuzSablonlari");
    }
}
