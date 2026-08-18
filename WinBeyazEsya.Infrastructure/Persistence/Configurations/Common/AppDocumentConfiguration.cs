using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Common;

public class AppDocumentConfiguration : IEntityTypeConfiguration<AppDocument>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<AppDocument> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.EntityName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.FileName).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Extension).IsRequired().HasMaxLength(10);
        builder.Property(x => x.ContentType).IsRequired().HasMaxLength(100);

        // VARBINARY(MAX) for SQL Server
        builder.Property(x => x.FileData)
               .IsRequired()
               .HasColumnType("varbinary(max)");

        builder.HasIndex(x => new { x.EntityName, x.EntityId });
    }
}

