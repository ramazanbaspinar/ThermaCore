using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Management;

public class UserConfiguration : IEntityTypeConfiguration<User>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        // builder.HasOne(x => x.UserRole)
        //     .WithMany()
        //     .HasForeignKey(x => x.UserRoleId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
