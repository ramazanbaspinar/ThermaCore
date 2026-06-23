using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Management;

public class CodeLogConfiguration : IEntityTypeConfiguration<CodeLog>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<CodeLog> builder)
    {
        builder.ToTable("CodeLogs");
    }
}
