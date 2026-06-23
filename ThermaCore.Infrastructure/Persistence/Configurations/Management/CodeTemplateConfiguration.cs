using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Management;

public class CodeTemplateConfiguration : IEntityTypeConfiguration<CodeTemplate>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<CodeTemplate> builder)
    {
        builder.ToTable("CodeTemplates");
    }
}
