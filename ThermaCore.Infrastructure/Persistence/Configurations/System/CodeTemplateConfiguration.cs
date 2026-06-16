using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Persistence.Configurations.System;

public class CodeTemplateConfiguration : IEntityTypeConfiguration<CodeTemplate>
{
    public void Configure(EntityTypeBuilder<CodeTemplate> builder)
    {
        builder.ToTable("CodeTemplates");
    }
}
