using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.System;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.System;

public class UserInterfaceTemplateConfiguration : IEntityTypeConfiguration<UserInterfaceTemplate>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<UserInterfaceTemplate> builder)
    {
        builder.ToTable("UserInterfaceTemplates");
    }
}

