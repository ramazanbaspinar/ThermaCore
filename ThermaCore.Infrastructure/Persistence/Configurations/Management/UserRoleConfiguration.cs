using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Management;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");

        builder.Property(x => x.RoleName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
