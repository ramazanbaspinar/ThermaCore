using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Persistence.Configurations.System;

public class UserInterfaceTemplateConfiguration : IEntityTypeConfiguration<UserInterfaceTemplate>
{
    public void Configure(EntityTypeBuilder<UserInterfaceTemplate> builder)
    {
        builder.ToTable("UserInterfaceTemplates");
    }
}
