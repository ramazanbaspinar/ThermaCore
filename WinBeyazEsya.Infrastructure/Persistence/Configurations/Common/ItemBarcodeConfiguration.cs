using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Common;

public class ItemBarcodeConfiguration : IEntityTypeConfiguration<ItemBarcode>
{
    public void Configure(EntityTypeBuilder<ItemBarcode> builder)
    {
        // Unique index for BarcodeValue to prevent conflicts
        builder.HasIndex(x => x.BarcodeValue).IsUnique();

        // Composite index for RecordId and ModuleType
        builder.HasIndex(x => new { x.RecordId, x.ModuleType });
    }
}

