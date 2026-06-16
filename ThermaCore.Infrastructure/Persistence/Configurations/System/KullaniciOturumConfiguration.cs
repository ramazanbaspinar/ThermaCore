using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Persistence.Configurations.System;

public class KullaniciOturumConfiguration : IEntityTypeConfiguration<KullaniciOturum>
{
    public void Configure(EntityTypeBuilder<KullaniciOturum> builder)
    {
        builder.ToTable("KullaniciOturumlari");
    }
}
