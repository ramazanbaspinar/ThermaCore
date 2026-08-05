using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Management;

public class CodeLogConfiguration : IEntityTypeConfiguration<CodeLog>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<CodeLog> builder)
    {
        builder.ToTable("CodeLogs");
    }
}

