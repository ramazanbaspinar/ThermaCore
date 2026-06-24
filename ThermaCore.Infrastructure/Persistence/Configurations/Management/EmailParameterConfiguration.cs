using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Management;

public class EmailParameterConfiguration : IEntityTypeConfiguration<EmailParameter>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<EmailParameter> builder)
    {
        builder.ToTable("EmailParameters");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.SmtpServer).HasMaxLength(200).IsRequired();
        builder.Property(x => x.SenderName).HasMaxLength(200).IsRequired();
        builder.Property(x => x.SenderEmail).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(200).IsRequired();
    }
}
