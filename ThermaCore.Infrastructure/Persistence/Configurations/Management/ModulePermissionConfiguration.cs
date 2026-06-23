using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Management;

public class ModulePermissionConfiguration : IEntityTypeConfiguration<ModulePermission>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ModulePermission> builder)
    {
        builder.ToTable("ModulePermissions");

        builder.HasOne(x => x.UserRole)
            .WithMany()
            .HasForeignKey(x => x.UserRoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
