using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Common;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Common;

public class ItemBarcodeConfiguration : IEntityTypeConfiguration<ItemBarcode>
{
    public void Configure(EntityTypeBuilder<ItemBarcode> builder)
    {
        // Non-unique index for BarcodeValue
        builder.HasIndex(x => x.BarcodeValue).IsUnique(false);

        // Composite index for RecordId and ModuleType
        builder.HasIndex(x => new { x.RecordId, x.ModuleType });
    }
}
