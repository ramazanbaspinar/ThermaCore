using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Management;

public class SystemParameterConfiguration : IEntityTypeConfiguration<SystemParameter>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<SystemParameter> builder)
    {
        builder.ToTable("SystemParameters");

        builder.Property(x => x.DefaultWastageRate)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.UpdatePath).HasMaxLength(250);
    }
}


