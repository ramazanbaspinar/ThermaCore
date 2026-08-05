using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Management;

public class SystemLicenseConfiguration : IEntityTypeConfiguration<SystemLicense>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<SystemLicense> builder)
    {
        builder.ToTable("SystemLicenses");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ServerHardwareId).HasMaxLength(100).IsRequired();
        builder.Property(x => x.LicenseKey).HasMaxLength(2000).IsRequired();
    }
}

