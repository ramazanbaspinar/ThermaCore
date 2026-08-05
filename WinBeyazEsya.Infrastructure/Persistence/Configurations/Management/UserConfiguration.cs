using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Management;

public class UserConfiguration : IEntityTypeConfiguration<User>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.UserRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

