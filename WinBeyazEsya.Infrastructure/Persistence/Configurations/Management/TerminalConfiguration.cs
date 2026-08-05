using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Management;

public class TerminalConfiguration : IEntityTypeConfiguration<Terminal>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Terminal> builder)
    {
        builder.ToTable("Terminals");
    }
}

