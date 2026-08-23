using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Purchasing;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Purchasing;

public class PurchaseReceiptConfiguration : IEntityTypeConfiguration<PurchaseReceipt>
{
    public void Configure(EntityTypeBuilder<PurchaseReceipt> builder)
    {
        builder.ToTable("PurchaseReceipts");

        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasIndex(x => x.SupplierId);
        builder.HasIndex(x => x.WarehouseId);

        builder.HasMany(x => x.Lines)
            .WithOne(x => x.PurchaseReceipt)
            .HasForeignKey(x => x.PurchaseReceiptId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
