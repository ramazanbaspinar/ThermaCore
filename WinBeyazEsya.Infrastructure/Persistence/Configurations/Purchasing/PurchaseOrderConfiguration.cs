using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Purchasing;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Purchasing;

public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.ToTable("PurchaseOrders");

        // Master Unique Index
        builder.HasIndex(x => x.Code).IsUnique();

        // Performans İndeksleri (IsActive, Status, FK'lar)
        builder.HasIndex(x => x.IsActive);
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.SupplierId);
        builder.HasIndex(x => x.WarehouseId);
        builder.HasIndex(x => x.CurrencyId);

        // İlişkiler
        builder.HasMany(x => x.Lines)
            .WithOne(x => x.PurchaseOrder)
            .HasForeignKey(x => x.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
