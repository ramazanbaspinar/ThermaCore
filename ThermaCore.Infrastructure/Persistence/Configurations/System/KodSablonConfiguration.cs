using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Persistence.Configurations.System;

public class KodSablonConfiguration : IEntityTypeConfiguration<KodSablon>
{
    public void Configure(EntityTypeBuilder<KodSablon> builder)
    {
        builder.ToTable("KodSablonlari");
    }
}
