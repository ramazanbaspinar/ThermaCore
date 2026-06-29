using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Management;

public class SystemParameterConfiguration : IEntityTypeConfiguration<SystemParameter>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<SystemParameter> builder)
    {
        builder.ToTable("SystemParameters");

        builder.Property(x => x.DefaultWastageRate)
            .HasColumnType("decimal(18,2)");
    }
}
