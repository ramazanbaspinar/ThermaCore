using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Security;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Master;

public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.ToTable("UserPermissions");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ModuleName)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasOne(x => x.User)
            .WithMany() // Assuming User doesn't have a collection of UserPermissions directly mapped to keep it simple
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

