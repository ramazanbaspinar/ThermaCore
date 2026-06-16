using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Management;

public class TenantDatabaseConfiguration : IEntityTypeConfiguration<TenantDatabase>
{
    public void Configure(EntityTypeBuilder<TenantDatabase> builder)
    {
        builder.ToTable("TenantDatabases");
    }
}
